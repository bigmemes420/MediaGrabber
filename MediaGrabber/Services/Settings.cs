using System;
using System.IO;
using System.Text.Json;

namespace MediaGrabber;

/// <summary>
/// User-configurable settings, persisted as settings.json next to the .exe.
/// </summary>
public sealed class AppSettings
{
    public string? YtDlpPath { get; set; }
    public string? FfmpegPath { get; set; }
    public string? OutputFolder { get; set; }
}

public static class SettingsStore
{
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public static string FilePath { get; } = Path.Combine(AppContext.BaseDirectory, "settings.json");

    /// <summary>
    /// Reads settings.json. Returns defaults if the file is missing, unreadable
    /// or corrupt — never throws.
    /// </summary>
    public static AppSettings Load()
    {
        try
        {
            if (!File.Exists(FilePath))
                return new AppSettings();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
        {
            return new AppSettings();
        }
    }

    /// <summary>
    /// Writes indented JSON atomically. Exceptions propagate to the caller.
    /// </summary>
    public static void Save(AppSettings settings)
    {
        var dir = Path.GetDirectoryName(FilePath);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);

        var json = JsonSerializer.Serialize(settings, Options);
        var temp = FilePath + ".tmp";
        File.WriteAllText(temp, json);
        File.Move(temp, FilePath, overwrite: true);
    }
}
