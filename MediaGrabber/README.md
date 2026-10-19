# MediaGrabber

A simple Windows (WinForms) GUI wrapper around
[yt-dlp](https://github.com/yt-dlp/yt-dlp) and
[ffmpeg](https://github.com/ffmpeg/ffmpeg). Paste a URL, choose what you want,
pick a format, and download.

## Requirements

- .NET 9 SDK (targets `net9.0-windows`).
- `yt-dlp.exe` and `ffmpeg.exe` must be available either:
  - on your `PATH`, or
  - dropped in the same folder as `MediaGrabber.exe`.

  Downloads: <https://github.com/yt-dlp/yt-dlp> and
  <https://github.com/ffmpeg/ffmpeg>. ffmpeg is required for audio extraction
  and for merging separate video/audio streams.

## Build & run

From the `MediaGrabber` folder:

```
dotnet build
dotnet run
```

## Usage

Paste a URL → pick **Video**, **Audio**, or **Both** → choose a format →
**Download**. Files land in the chosen output folder named after the media
title.
