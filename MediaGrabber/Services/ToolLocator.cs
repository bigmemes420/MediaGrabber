using System;
using System.IO;

namespace MediaGrabber;

/// <summary>
/// Finds the external command-line tools the app shells out to. Search order is
/// the app's own directory first (so a tool dropped next to the .exe wins), then
/// each entry on the PATH environment variable.
/// </summary>
public static class ToolLocator
{
    public static string? FindYtDlp() => FindYtDlp(null);

    public static string? FindFfmpeg() => FindFfmpeg(null);

    public static string? FindYtDlp(string? preferred) => Prefer(preferred) ?? Find("yt-dlp");

    public static string? FindFfmpeg(string? preferred) => Prefer(preferred) ?? Find("ffmpeg");

    private static string? Prefer(string? preferred) =>
        !string.IsNullOrWhiteSpace(preferred) && File.Exists(preferred)
            ? Path.GetFullPath(preferred)
            : null;

    private static string? Find(string name)
    {
        foreach (var candidateName in CandidateNames(name))
        {
            var local = Path.Combine(AppContext.BaseDirectory, candidateName);
            if (File.Exists(local))
                return local;
        }

        var path = Environment.GetEnvironmentVariable("PATH");
        if (string.IsNullOrEmpty(path))
            return null;

        foreach (var dir in path.Split(Path.PathSeparator))
        {
            if (string.IsNullOrWhiteSpace(dir))
                continue;

            foreach (var candidateName in CandidateNames(name))
            {
                try
                {
                    var full = Path.Combine(dir.Trim(), candidateName);
                    if (File.Exists(full))
                        return full;
                }
                catch (ArgumentException)
                {
                    // Skip malformed PATH entries (illegal characters, etc.).
                }
            }
        }

        return null;
    }

    private static string[] CandidateNames(string name) =>
        OperatingSystem.IsWindows()
            ? new[] { name + ".exe", name }
            : new[] { name };
}
