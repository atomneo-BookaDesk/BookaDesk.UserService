using BookaDesk.UserService.Application.Commands;
using BookaDesk.UserService.Application.Utils.PasswordHashers;
using BookaDesk.UserService.Application.Validators.CommandValidators;
using BookaDesk.UserService.Domain.Models;
using BookaDesk.UserService.Domain.Services;

namespace BookaDesk.UserService.Application.CommandHandlers;

/// <summary>
/// A handler class for create first user command
/// </summary>
public class CreateFirstUserCommandHandler(
    IUsersService usersService,
    ICommandValidator<CreateFirstUserCommand> validator,
    IPasswordHasher passwordHasher
    ): ICommandHandler<CreateFirstUserCommand>
{
    public async Task Handle(CreateFirstUserCommand command)
    {
        validator.Validate(command);
        var passwordHash = passwordHasher.HashPassword(command.Password);
        await usersService.CreateFirstUserAsync(new User(command.Email, passwordHash));
    }
}