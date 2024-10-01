using BookaDesk.UserService.Domain.Exceptions;

namespace BookaDesk.UserService.Application.Exceptions;

public class ValidationException(string message) : Exception(message), IUserServiceException;