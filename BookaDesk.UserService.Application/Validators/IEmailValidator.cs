namespace BookaDesk.UserService.Application.Validators;

public interface IEmailValidator
{
    /// <summary>
    /// Validates if email address has correct format
    /// </summary>
    /// <param name="email">Email address to validate</param>
    void Validate(string email);
}