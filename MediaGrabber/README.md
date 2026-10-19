# MediaGrabber

A simple Windows (WinForms) GUI wrapper around
[yt-dlp](https://github.com/yt-dlp/yt-dlp) and
[ffmpeg](https://github.com/ffmpeg/ffmpeg). Paste a URL, choose what you want,
pick a format, and download.

## Requirements

- .NET 9 SDK to build (targets `net9.0-windows`).
- The app is **framework-dependent**: the host must have the
  [.NET 9 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/9.0)
  installed to run it. The runtime is **not** bundled.
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

A normal `dotnet build` produces the app dll plus an `MediaGrabber.exe` launcher
and the loose `MediaGrabber.runtimeconfig.json` and `MediaGrabber.deps.json`
beside them (normal for a non-single-file build). The runtime is not copied —
the installed .NET 9 Desktop Runtime is used. The output lands under
`bin\Debug\net9.0-windows\win-x64\`.

## Publish

To produce a single framework-dependent `MediaGrabber.exe`, either run:

```
dotnet publish -c Release
```

or in Visual Studio → **Publish** using the bundled **FolderProfile** profile
(`Properties\PublishProfiles\FolderProfile.pubxml`).

Publish targets `win-x64` and embeds the app dll, `runtimeconfig.json`,
`deps.json` and the debug symbols into one `MediaGrabber.exe`. The .NET runtime
is **not** bundled, so the exe is small (a few MB) and requires the .NET 9
Desktop Runtime on the host. The result is at:

```
bin\Release\net9.0-windows\win-x64\publish\MediaGrabber.exe
```

`yt-dlp.exe` and `ffmpeg.exe` are still required at runtime (see above) — they are
external tools and are not bundled.

## Usage

Paste a URL → pick **Video**, **Audio**, or **Both** → choose a format →
**Download**. Files land in the chosen output folder named after the media
title.
