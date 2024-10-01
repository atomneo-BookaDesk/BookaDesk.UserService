using BookaDesk.UserService.Domain.Exceptions;
using BookaDesk.UserService.Domain.Models;
using BookaDesk.UserService.Domain.Repositories;

namespace BookaDesk.UserService.Domain.Services;

public class UsersService(IUserRepository userRepository): IUsersService
{
    public async Task CreateFirstUserAsync(User user)
    {
        try
        {
            await userRepository.GetAllAsync();
        }
        catch (UserNotFoundException e)
        {
            // This should occur only in empty database, so it's correct and possible to create first user
            await userRepository.CreateAsync(user);
            return;
        }

        throw new IncorrectApplicationStateException("Application already initialized. Unable to create first user.");
    }
}