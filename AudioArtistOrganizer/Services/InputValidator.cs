using AudioArtistOrganizer.Interfaces;

namespace AudioArtistOrganizer.Services;

public class InputValidator : IInputValidator
{
    public bool IsUserInputPositive(string response)
    {
        // If user does not input anything, we take it as a positive input (y).
        if (string.IsNullOrWhiteSpace(response))
        {
            response = "y";
        }

        response = response.Trim().ToLowerInvariant();
        return "y".Equals(response, StringComparison.InvariantCultureIgnoreCase);
    }
}