namespace AudioArtistOrganizer.Interfaces;

public interface IInputValidator
{
    /// <summary>
    /// Analyzes if the user input is positive or not (y).
    /// </summary>
    /// <param name="response">User response (input)</param>
    /// <returns>Is user input positive</returns>
    bool IsUserInputPositive(string response);
}