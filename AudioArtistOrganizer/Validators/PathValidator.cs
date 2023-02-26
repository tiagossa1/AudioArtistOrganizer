using AudioArtistOrganizer.Interfaces;

namespace AudioArtistOrganizer.Validators;

public class PathValidator : IPathValidator
{
    public bool IsPathValid(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return false;
        }

        var doesPathExists = Directory.Exists(path);
        if (!doesPathExists)
        {
            return false;
        }

        var attributes = File.GetAttributes(path);
        if (!attributes.HasFlag(FileAttributes.Directory))
        {
            return false;
        }

        return true;
    }
}