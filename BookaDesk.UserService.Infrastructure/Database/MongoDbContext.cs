using BookaDesk.UserService.Infrastructure.Models;
using BookaDesk.UserService.Infrastructure.Settings;
using MongoDB.Driver;

namespace BookaDesk.UserService.Infrastructure.Database
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<UserDbModel> Users => _database.GetCollection<UserDbModel>("Users");
    }
}