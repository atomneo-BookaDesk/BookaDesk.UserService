using BookaDesk.UserService.Domain.Models;

namespace BookaDesk.UserService.Domain.Services;

public interface IUsersService
{
    Task CreateFirstUserAsync(User user);
}