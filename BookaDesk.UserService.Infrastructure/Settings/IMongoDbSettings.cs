namespace BookaDesk.UserService.Infrastructure.Settings;

public interface IMongoDbSettings
{
    string ConnectionString { get; }
    string DatabaseName { get; }
}