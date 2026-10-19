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

Every build is **self-contained**: a normal `dotnet build` / Visual Studio F5
bundles the .NET 9 runtime into the output (`win-x64`), so the app runs with no
installed .NET. A non-bundled build still writes the loose
`MediaGrabber.runtimeconfig.json` and `MediaGrabber.deps.json` beside the exe
(unavoidable outside a single-file publish) — this is expected for a local build.
The output lands under `bin\Debug\net9.0-windows\win-x64\`.

## Publish

To produce a single, self-contained `MediaGrabber.exe` that needs **no installed
.NET runtime**, either run:

```
dotnet publish -c Release
```

or in Visual Studio → **Publish** using the bundled **FolderProfile** profile
(`Properties\PublishProfiles\FolderProfile.pubxml`).

Publish targets `win-x64` and bundles the .NET runtime and all native/WinForms
libraries into one file. `runtimeconfig.json`, `deps.json` and the debug symbols
are embedded in the exe (not emitted as loose files), so publish produces a
single `MediaGrabber.exe`. The result is at:

```
bin\Release\net9.0-windows\win-x64\publish\MediaGrabber.exe
```

`yt-dlp.exe` and `ffmpeg.exe` are still required at runtime (see above) — they are
external tools and are not bundled.

## Usage

Paste a URL → pick **Video**, **Audio**, or **Both** → choose a format →
**Download**. Files land in the chosen output folder named after the media
title.
