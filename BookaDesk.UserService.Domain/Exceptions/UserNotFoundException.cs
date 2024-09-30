namespace BookaDesk.UserService.Domain.Exceptions;

public class UserNotFoundException(string message) : Exception(message), IUserServiceException;