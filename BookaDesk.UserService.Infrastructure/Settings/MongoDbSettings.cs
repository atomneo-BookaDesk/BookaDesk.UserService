namespace BookaDesk.UserService.Infrastructure.Settings;

public class MongoDbSettings : IMongoDbSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}