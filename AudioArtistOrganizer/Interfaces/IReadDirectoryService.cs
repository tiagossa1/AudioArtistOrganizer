namespace AudioArtistOrganizer.Interfaces;

public interface IReadDirectoryService
{
    /// <summary>
    /// Reads a directory path for music files.
    /// </summary>
    /// <param name="directoryPath">Directory path</param>
    /// <returns>List of music files</returns>
    List<string> FindAllMusicFiles(string directoryPath);
}