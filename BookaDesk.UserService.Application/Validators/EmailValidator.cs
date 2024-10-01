using System.Net.Mail;

namespace BookaDesk.UserService.Application.Validators;

public class EmailValidator : IEmailValidator
{
    public void Validate(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            throw new ArgumentException("Email is not valid.");
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var mail = new MailAddress(email);
            return mail.Address == email;
        }
        catch
        {
            return false;
        }
    }
}