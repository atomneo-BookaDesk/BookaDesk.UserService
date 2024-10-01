using BookaDesk.UserService.Domain.Repositories;
using BookaDesk.UserService.Infrastructure.Database;
using BookaDesk.UserService.Infrastructure.Repositories;
using BookaDesk.UserService.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BookaDesk.UserService.Infrastructure;

public static class Configure
{
    public static void ConfigureMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(nameof(MongoDbSettings));
        services.Configure<MongoDbSettings>(section);
        services.AddSingleton<IMongoDbSettings>(sp =>
            sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

        services.AddSingleton<IMongoDbContext, MongoDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();
    }
}