using Microsoft.AspNetCore.Mvc;

namespace BookaDesk.UserService.Api.Endpoints;

public static class RegisterFirstUserEndpoint
{
    public static void MapRegisterFirstUserEndpoint(this WebApplication app)
    {
        app.MapPost(
                "/register-first-user",
                async (RegisterFirstUserCommand command, [FromServices] ICommandHandler<RegisterFirstUserCommand> handler) =>
                {
                    await handler.Handle(command);
                    return Results.Ok("User registered successfully!");
                }
            )
            .WithName("RegisterFirstUser")
            .WithOpenApi();
    }
}