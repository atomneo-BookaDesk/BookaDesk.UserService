using BookaDesk.UserService.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace BookaDesk.UserService.Application.CommandHandlers;

public static class Configure
{
    public static void ConfigureCommandHandlers(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateFirstUserCommand>, CreateFirstUserCommandHandler>();
    }
}