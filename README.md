# 🧑 AudioArtistOrganizer
**Description**: Small console app made in C# that takes a directory path, scans for audio files, extracts the artist name and creates a folder with that artist name in a given directory path. It will also create 5 sub-folders: "Acapellas", "Instrumentals", "Remixes", "Studio Albums" and "Singles".

# ⚠️ Docker
Although not tested, this project should be docker-ready by using Jetbrains' Rider dockerfile template.

# AppSettings
To be able to test this app, please, make sure you configure `appsettings.json` correctly.

**MusicFolderPath**: This is the directory path that the app will use to scan your audio files.

**FolderPathToCreate**: This is the directory path that the app will use to create the artist's folder.

# Third party NuGet packages
[Taglib-Sharp](https://github.com/mono/taglib-sharp) - Awesome NuGet package used to extract metadata from the audio files.