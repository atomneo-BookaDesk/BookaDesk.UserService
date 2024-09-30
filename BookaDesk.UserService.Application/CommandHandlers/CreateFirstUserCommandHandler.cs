using BookaDesk.UserService.Application.Commands;
using BookaDesk.UserService.Application.Validators.CommandValidators;

namespace BookaDesk.UserService.Application.CommandHandlers;

/// <summary>
/// A handler class for create first user command
/// </summary>
public class CreateFirstUserCommandHandler(IUsersService usersService, ICommandValidator<CreateFirstUserCommand> validator): ICommandHandler<CreateFirstUserCommand>
{
    public async Task Handle(CreateFirstUserCommand command)
    {
        validator.Validate(command);
        await usersService.CreateFirstUserAsync(command.Email, command.Password);
    }
}