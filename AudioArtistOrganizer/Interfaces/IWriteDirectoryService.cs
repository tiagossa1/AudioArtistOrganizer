namespace AudioArtistOrganizer.Interfaces;

public interface IWriteDirectoryService
{
    /// <summary>
    /// Creates main artist folder.
    /// </summary>
    /// <param name="mainDirectoryPath"></param>
    /// <param name="artistName">Artist name</param>
    /// <returns><see cref="bool"/></returns>
    bool CreateArtistFolder(string mainDirectoryPath, string artistName);

    /// <summary>
    /// Creates music sub-folders - Instrumentals, Remixes, Acapellas, Studio Albums, Singles.
    /// </summary>
    /// <param name="mainDirectoryPath"></param>
    /// <param name="artistName"></param>
    /// <returns><see cref="bool"/></returns>
    IReadOnlyCollection<string> CreateMusicSubfolders(string mainDirectoryPath, string artistName);
}