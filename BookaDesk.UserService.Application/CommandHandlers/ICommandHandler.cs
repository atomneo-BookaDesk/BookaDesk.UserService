namespace BookaDesk.UserService.Application.CommandHandlers;

public interface ICommandHandler<in T>
{
    Task Handle(T command);
}