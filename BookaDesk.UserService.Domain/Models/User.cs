namespace BookaDesk.UserService.Domain.Models;

public class User(string email, string password, Guid id) : IDomainModel
{
    public Guid Id { get; set; } = id;

    public string Email { get; set; } = email;

    public string Password { get; set; } = password;
}