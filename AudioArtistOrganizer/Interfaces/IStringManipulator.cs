namespace AudioArtistOrganizer.Interfaces;

public interface IStringManipulator
{
    /// <summary>
    /// Normalizes a string and converts it into title case. Removes accents, trims and culture invariant lower cases it.
    /// </summary>
    /// <param name="str">String to normalize</param>
    /// <param name="titleCaseCultureCode"></param>
    /// <returns>Normalized string</returns>
    string Normalize(string str, string titleCaseCultureCode = "en-US");
}