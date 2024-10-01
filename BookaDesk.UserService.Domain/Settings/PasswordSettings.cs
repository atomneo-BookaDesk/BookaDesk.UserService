using BookaDesk.UserService.Domain.Exceptions;

namespace BookaDesk.UserService.Domain.Settings;

/// <summary>
/// Represents password-related settings in the application.
/// </summary>
public class PasswordSettings
{
    public int MinimumLength { get; }

    public PasswordSettings(int minimumLength)
    {
        if (minimumLength <= 0)
            throw new IncorrectSettingsException("Password length must be greater than zero.");

        MinimumLength = minimumLength;
    }
}