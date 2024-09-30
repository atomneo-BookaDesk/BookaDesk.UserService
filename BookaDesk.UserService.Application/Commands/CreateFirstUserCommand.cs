namespace BookaDesk.UserService.Application.Commands;

/// <summary>
/// Command structure for register first user
/// </summary>
/// <param name="Email">User email</param>
/// <param name="Password">User password</param>
/// <param name="ConfirmPassword">Password confirmation</param>
public record struct CreateFirstUserCommand(string Email, string Password, string ConfirmPassword) : ICommand<CreateFirstUserCommand>;