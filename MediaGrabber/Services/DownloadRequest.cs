namespace MediaGrabber;

public enum MediaKind
{
    Video,
    Audio,
    Both
}

public sealed class DownloadRequest
{
    public required string Url { get; init; }
    public required MediaKind Kind { get; init; }

    /// <summary>
    /// Container for video (e.g. "mp4", "mkv", "webm") or codec/container for
    /// audio (e.g. "mp3", "m4a", "wav", "opus", "flac").
    /// </summary>
    public required string Format { get; init; }

    public required string OutputFolder { get; init; }

    /// <summary>
    /// Video (and Both): "Best", "2160p", "1440p", "1080p", "720p", "480p".
    /// Audio: "Best", "Lossless", "320k", "256k", "192k", "128k".
    /// </summary>
    public required string Quality { get; init; }
}
