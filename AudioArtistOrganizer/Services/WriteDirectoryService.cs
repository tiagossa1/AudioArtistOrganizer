using AudioArtistOrganizer.Interfaces;
using TagLib.Riff;

namespace AudioArtistOrganizer.Services;

public class WriteDirectoryService : IWriteDirectoryService
{
    private readonly IReadOnlyCollection<string> _subFoldersToCreate = new List<string>
    {
        "Instrumentals",
        "Singles",
        "Studio Albums",
        "Acapellas",
        "Remixes"
    }.AsReadOnly();

    public bool CreateArtistFolder(string mainDirectoryPath, string artistName)
    {
        try
        {
            var combinedPath = Path.Combine(mainDirectoryPath, artistName);
            var isArtistDirectoryCreated = Directory.Exists(combinedPath);
        
            if (!isArtistDirectoryCreated)
            {
                Directory.CreateDirectory(combinedPath);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IReadOnlyCollection<string> CreateMusicSubfolders(string mainDirectoryPath, string artistName)
    {
        try
        {
            var subFoldersCreated = new List<string>();
            
            foreach (var subFolderPath in _subFoldersToCreate)
            {
                var combinedPath = Path.Combine(mainDirectoryPath, artistName, subFolderPath);
                var directoryExists = Directory.Exists(combinedPath);
                if (directoryExists)
                {
                    continue;
                }
                
                subFoldersCreated.Add(combinedPath);

                Directory.CreateDirectory(combinedPath);
            }

            return subFoldersCreated;
        }
        catch (Exception)
        {
            return new List<string>(0);
        }
    }
}