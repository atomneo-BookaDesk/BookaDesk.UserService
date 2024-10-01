using BookaDesk.UserService.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookaDesk.UserService.Domain;

public static class Configure
{
    public static void ConfigureDomain(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();
    }
}