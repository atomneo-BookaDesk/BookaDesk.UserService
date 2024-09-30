namespace BookaDesk.UserService.Api.Endpoints;

public static class ConfigureEndpoints
{
    public static void MapUserServiceEndpoints(this WebApplication app)
    {
        app.MapRegisterFirstUserEndpoint();
    }
}