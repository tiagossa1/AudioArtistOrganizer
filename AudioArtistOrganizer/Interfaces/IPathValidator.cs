namespace AudioArtistOrganizer.Interfaces;

public interface IPathValidator
{
    /// <summary>
    /// Checks if path exists and is a directory
    /// </summary>
    /// <returns><see cref="bool"/></returns>
    bool IsPathValid(string path);
}