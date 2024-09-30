using BookaDesk.UserService.Infrastructure.Models;
using MongoDB.Driver;

namespace BookaDesk.UserService.Infrastructure.Database
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<UserDbModel> Users => _database.GetCollection<UserDbModel>("Users");
    }
}