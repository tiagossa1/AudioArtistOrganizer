using AudioArtistOrganizer.Records;

namespace AudioArtistOrganizer.Interfaces;

public interface IReadMusicFile
{
    MusicMetadata GetMusicMetadataByPath(string filePath);
}