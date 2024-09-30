namespace BookaDesk.UserService.Domain.Services;

public interface IUsersService
{
    Task CreateFirstUserAsync(string email, string password);
}