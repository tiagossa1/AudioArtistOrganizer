using AudioArtistOrganizer.Interfaces;

namespace AudioArtistOrganizer.Services;

public class ReadDirectoryService : IReadDirectoryService
{
    private readonly IReadOnlyCollection<string> _validMusicExtensions = new List<string>
    {
        "m4a",
        "mp3",
        "flac",
        "wav",
        "wma", // Is this even a thing?
        "aac"
    }.AsReadOnly();

    public List<string> FindAllMusicFiles(string directoryPath)
    {
        return Directory
            .EnumerateFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly)
            .Where(fileName => _validMusicExtensions
                .Any(extension =>
                extension == Path
                    .GetExtension(fileName)
                    .TrimStart('.')
                    .ToLowerInvariant()))
            .ToList();
    }
}