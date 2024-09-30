using BookaDesk.UserService.Domain.Models;

namespace BookaDesk.UserService.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByEmailAsync(string email);
}