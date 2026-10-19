using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MediaGrabber;

/// <summary>
/// Drives yt-dlp (which in turn calls ffmpeg via --ffmpeg-location) and streams
/// every output line back to the caller. One instance can run many downloads.
/// </summary>
public sealed class DownloadService
{
    public async Task<int> RunAsync(DownloadRequest request, Action<string> onOutput, CancellationToken ct)
    {
        var settings = SettingsStore.Load();

        var ytDlp = ToolLocator.FindYtDlp(settings.YtDlpPath);
        if (ytDlp is null)
        {
            onOutput("ERROR: yt-dlp was not found. Put yt-dlp.exe next to MediaGrabber.exe or on your PATH.");
            return -1;
        }

        var ffmpeg = ToolLocator.FindFfmpeg(settings.FfmpegPath);
        var ffmpegDir = ffmpeg is null ? null : Path.GetDirectoryName(ffmpeg);

        if (ffmpeg is null)
        {
            // ffmpeg is mandatory for Audio (extraction) and Both (guaranteed
            // merge into one file); for plain Video it is only a warning.
            if (request.Kind == MediaKind.Video)
            {
                onOutput("WARNING: ffmpeg was not found. Merging separate video+audio streams needs ffmpeg; the download may fail or fall back to a single pre-merged stream.");
            }
            else
            {
                var need = request.Kind == MediaKind.Audio
                    ? "Extracting audio needs ffmpeg."
                    : "Merging video+audio into one file needs ffmpeg.";
                onOutput($"ERROR: ffmpeg was not found. {need} Put ffmpeg.exe next to MediaGrabber.exe or on your PATH.");
                return -1;
            }
        }

        onOutput($"Using yt-dlp: {ytDlp}");
        if (ffmpeg is not null)
            onOutput($"Using ffmpeg: {ffmpeg}");

        switch (request.Kind)
        {
            case MediaKind.Video:
            case MediaKind.Both:
                return await RunPassAsync(ytDlp, BuildVideoArgs(request, ffmpegDir), onOutput, ct);

            case MediaKind.Audio:
                return await RunPassAsync(ytDlp, BuildAudioArgs(request, ffmpegDir, onOutput), onOutput, ct);

            default:
                onOutput($"ERROR: unknown media kind '{request.Kind}'.");
                return -1;
        }
    }

    private static List<string> BuildCommonArgs(DownloadRequest request, string? ffmpegDir)
    {
        var args = new List<string>
        {
            "--newline",
            "-P", request.OutputFolder,
            "-o", "%(title)s.%(ext)s",
        };

        if (ffmpegDir is not null)
        {
            args.Add("--ffmpeg-location");
            args.Add(ffmpegDir);
        }

        return args;
    }

    private static List<string> BuildVideoArgs(DownloadRequest request, string? ffmpegDir)
    {
        var args = BuildCommonArgs(request, ffmpegDir);

        args.Add("-f");
        if (string.Equals(request.Quality, "Best", StringComparison.OrdinalIgnoreCase)
            || !TryParseLeadingDigits(request.Quality, out var height))
        {
            args.Add("bv*+ba/b");
        }
        else
        {
            args.Add($"bv*[height<={height}]+ba/b[height<={height}]");
        }

        args.Add("--merge-output-format");
        args.Add(request.Format);
        args.Add(request.Url);
        return args;
    }

    private static readonly HashSet<string> LosslessFormats =
        new(StringComparer.OrdinalIgnoreCase) { "wav", "flac" };

    private static List<string> BuildAudioArgs(DownloadRequest request, string? ffmpegDir, Action<string> onOutput)
    {
        var args = BuildCommonArgs(request, ffmpegDir);

        var lossless = string.Equals(request.Quality, "Lossless", StringComparison.OrdinalIgnoreCase);
        var audioFormat = request.Format;
        if (lossless && !LosslessFormats.Contains(request.Format))
        {
            audioFormat = "flac";
            onOutput($"Lossless selected; encoding to FLAC instead of {request.Format}.");
        }

        string audioQuality;
        if (lossless
            || string.Equals(request.Quality, "Best", StringComparison.OrdinalIgnoreCase)
            || !TryParseLeadingDigits(request.Quality, out var bitrate))
        {
            audioQuality = "0";
        }
        else
        {
            audioQuality = $"{bitrate}K";
        }

        args.Add("-x");
        args.Add("--audio-format");
        args.Add(audioFormat);
        args.Add("--audio-quality");
        args.Add(audioQuality);
        args.Add(request.Url);
        return args;
    }

    private static bool TryParseLeadingDigits(string? value, out int number)
    {
        number = 0;
        if (string.IsNullOrEmpty(value))
            return false;

        var end = 0;
        while (end < value.Length && char.IsAsciiDigit(value[end]))
            end++;

        return end > 0
            && int.TryParse(value.AsSpan(0, end), NumberStyles.None, CultureInfo.InvariantCulture, out number);
    }

    private static async Task<int> RunPassAsync(string exe, List<string> args, Action<string> onOutput, CancellationToken ct)
    {
        var psi = new ProcessStartInfo
        {
            FileName = exe,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };
        foreach (var arg in args)
            psi.ArgumentList.Add(arg);

        onOutput($"> yt-dlp {string.Join(' ', args)}");

        using var process = new Process { StartInfo = psi };

        var done = new TaskCompletionSource();
        var pending = 2;

        void OnData(object sender, DataReceivedEventArgs e)
        {
            if (e.Data is not null)
            {
                onOutput(e.Data);
            }
            else if (Interlocked.Decrement(ref pending) == 0)
            {
                done.TrySetResult();
            }
        }

        process.OutputDataReceived += OnData;
        process.ErrorDataReceived += OnData;

        try
        {
            process.Start();
        }
        catch (Exception ex)
        {
            onOutput($"ERROR: failed to start yt-dlp: {ex.Message}");
            return -1;
        }

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        using (ct.Register(() =>
        {
            try
            {
                if (!process.HasExited)
                    process.Kill(entireProcessTree: true);
            }
            catch
            {
                // Process may have exited between the check and the kill.
            }
        }))
        {
            await process.WaitForExitAsync(CancellationToken.None);
            // Ensure all buffered output has been flushed to onOutput.
            await done.Task;
        }

        if (ct.IsCancellationRequested)
        {
            onOutput("Cancelled.");
            ct.ThrowIfCancellationRequested();
        }

        onOutput($"yt-dlp exited with code {process.ExitCode}.");
        return process.ExitCode;
    }
}
