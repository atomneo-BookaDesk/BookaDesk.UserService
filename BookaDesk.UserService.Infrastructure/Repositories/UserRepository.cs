using BookaDesk.UserService.Domain.Exceptions;
using BookaDesk.UserService.Domain.Models;
using BookaDesk.UserService.Domain.Repositories;
using BookaDesk.UserService.Infrastructure.Database;
using BookaDesk.UserService.Infrastructure.Models;
using MongoDB.Driver;

namespace BookaDesk.UserService.Infrastructure.Repositories;

public class UserRepository(IMongoDbContext context) : IUserRepository
{
    private readonly IMongoCollection<UserDbModel> _users = context.Users;

    public async Task<User> GetByIdAsync(Guid id)
    {
        var userEntity = await _users.Find(u => u.Id == id.ToString()).FirstOrDefaultAsync();
        if (userEntity is not null)
            return ToDomainModel(userEntity);

        throw new UserNotFoundException($"User with id {id} not found.");
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var userEntities = await _users.Find(Builders<UserDbModel>.Filter.Empty).ToListAsync();

        if (userEntities.Any())
        {
            return userEntities.Select(ToDomainModel);
        }

        throw new UserNotFoundException("No users found in the database.");
    }

    public async Task CreateAsync(User user)
    {
        await _users.InsertOneAsync(ToDbModel(user));
    }

    public async Task UpdateAsync(Guid id, User user)
    {
        await _users.ReplaceOneAsync(e => e.Id == id.ToString(), ToDbModel(user));
    }

    public async Task DeleteAsync(Guid id)
    {
        await _users.DeleteOneAsync(e => e.Id == id.ToString());
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var userEntity = await _users.Find(user => user.Email == email).FirstOrDefaultAsync();
        if (userEntity is not null)
        {
            return ToDomainModel(userEntity);
        }

        throw new UserNotFoundException($"User with email {email} not found.");
    }

    private User ToDomainModel(UserDbModel userEntity)
    {
        return new User(userEntity.Email, userEntity.PasswordHash, userEntity.Id);
    }

    private UserDbModel ToDbModel(User user)
    {
        return new UserDbModel(user.Email, user.PasswordHash)
        {
            Id = user.Id.ToString()
        };
    }
}