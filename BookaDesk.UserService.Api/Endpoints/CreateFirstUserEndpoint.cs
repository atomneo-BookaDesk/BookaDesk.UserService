using BookaDesk.UserService.Application.CommandHandlers;
using BookaDesk.UserService.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BookaDesk.UserService.Api.Endpoints;

public static class CreateFirstUserEndpoint
{
    public static void MapCreateFirstUserEndpoint(this WebApplication app)
    {
        app.MapPost(
                "/create-first-user",
                async (CreateFirstUserCommand command, [FromServices] ICommandHandler<CreateFirstUserCommand> handler) =>
                {
                    await handler.Handle(command);
                    return Results.Ok("User created successfully!");
                }
            )
            .WithName("CreateFirstUser")
            .WithOpenApi();
    }
}