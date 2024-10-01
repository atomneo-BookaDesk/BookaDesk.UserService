namespace BookaDesk.UserService.Domain.Exceptions;

public class IncorrectSettingsException(string message) : Exception(message), IUserServiceException
{

}