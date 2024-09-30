namespace BookaDesk.UserService.Api.Endpoints;

public static class Configure
{
    public static void MapUserServiceEndpoints(this WebApplication app)
    {
        app.MapCreateFirstUserEndpoint();
    }
}