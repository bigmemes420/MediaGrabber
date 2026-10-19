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

A normal `dotnet build` / Visual Studio F5 produces a framework-dependent build
(requires the .NET 9 runtime installed), with `MediaGrabber.runtimeconfig.json`
and `MediaGrabber.deps.json` beside the exe — this is expected for a local build.

## Publish

To produce a single, self-contained `MediaGrabber.exe` that needs **no installed
.NET runtime**:

```
dotnet publish -c Release
```

This targets `win-x64` and bundles the .NET runtime and all native/WinForms
libraries into one file. `runtimeconfig.json`, `deps.json` and the debug symbols
are embedded in the exe (not emitted as loose files), so publish produces a
single `MediaGrabber.exe`. Use `dotnet publish -c Release` for this guaranteed
single-file output (a custom VS publish profile may override these settings). The
result is at:

```
bin\Release\net9.0-windows\win-x64\publish\MediaGrabber.exe
```

`yt-dlp.exe` and `ffmpeg.exe` are still required at runtime (see above) — they are
external tools and are not bundled.

## Usage

Paste a URL → pick **Video**, **Audio**, or **Both** → choose a format →
**Download**. Files land in the chosen output folder named after the media
title.
