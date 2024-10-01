using BookaDesk.UserService.Application.Commands;
using BookaDesk.UserService.Application.Exceptions;

namespace BookaDesk.UserService.Application.Validators.CommandValidators;

public class CreateFirstUserCommandValidator(IEmailValidator emailValidator) : ICommandValidator<CreateFirstUserCommand>
{
    private readonly int _minimumPasswordLength = 8;

    /// <summary>
    /// Validates create first user command
    /// </summary>
    /// <param name="command">Command to validate</param>
    /// <exception cref="ValidationException"></exception>
    public void Validate(CreateFirstUserCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Password))
            throw new ValidationException("Password cannot be empty.");

        if (command.Password.Length < _minimumPasswordLength)
            throw new ValidationException($"Password must be at least {_minimumPasswordLength} characters long.");

        if (command.Password != command.ConfirmPassword)
            throw new ValidationException("Password must be equal to confirm password");

        emailValidator.Validate(command.Email);
    }
}