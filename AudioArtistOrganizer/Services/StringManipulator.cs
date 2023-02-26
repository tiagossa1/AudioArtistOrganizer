using System.Globalization;
using System.Text;
using AudioArtistOrganizer.Interfaces;

namespace AudioArtistOrganizer.Services;

public class StringManipulator : IStringManipulator
{
    public string Normalize(string str, string titleCaseCultureCode = "en-US")
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return null;
        }

        var textInfo = new CultureInfo(titleCaseCultureCode, false).TextInfo;

        var artistNameWithoutAccents = new string(str
            .Normalize(NormalizationForm.FormD)
            .ToCharArray()
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            .ToArray());

        return textInfo.ToTitleCase(artistNameWithoutAccents.ToLowerInvariant().Trim());
    }
}