using BookaDesk.UserService.Infrastructure.Models;
using MongoDB.Driver;

namespace BookaDesk.UserService.Infrastructure.Database;

public interface IMongoDbContext
{
    IMongoCollection<UserDbModel> Users { get; }
}