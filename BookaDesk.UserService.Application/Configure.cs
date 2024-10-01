using BookaDesk.UserService.Application.CommandHandlers;
using BookaDesk.UserService.Application.Commands;
using BookaDesk.UserService.Application.Utils.PasswordHashers;
using BookaDesk.UserService.Application.Validators;
using BookaDesk.UserService.Application.Validators.CommandValidators;
using Microsoft.Extensions.DependencyInjection;

namespace BookaDesk.UserService.Application;

public static class Configure
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateFirstUserCommand>, CreateFirstUserCommandHandler>();
        services.AddScoped<ICommandValidator<CreateFirstUserCommand>, CreateFirstUserCommandValidator>();
        services.AddScoped<IEmailValidator, EmailValidator>();
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
    }
}