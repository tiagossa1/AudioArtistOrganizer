using AudioArtistOrganizer.Interfaces;
using AudioArtistOrganizer.Records;

namespace AudioArtistOrganizer.Services;

public class ReadMusicFile : IReadMusicFile
{
    private readonly IStringManipulator _stringManipulator;

    public ReadMusicFile(IStringManipulator stringManipulator)
    {
        _stringManipulator = stringManipulator;
    }

    public MusicMetadata GetMusicMetadataByPath(string filePath)
    {
        var tFile = TagLib.File.Create(filePath);
        return new MusicMetadata(_stringManipulator.Normalize(tFile.Tag.FirstPerformer));
    }
}