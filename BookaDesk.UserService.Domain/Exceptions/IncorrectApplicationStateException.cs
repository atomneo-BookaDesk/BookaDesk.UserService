namespace BookaDesk.UserService.Domain.Exceptions;

public class IncorrectApplicationStateException(string message) : Exception(message), IUserServiceException;