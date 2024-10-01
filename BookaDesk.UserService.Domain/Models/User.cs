namespace BookaDesk.UserService.Domain.Models;

public class User(string email, string passwordHash, string id = "") : IDomainModel
{
    public string Id { get; set; } = id;

    public string Email { get; set; } = email;

    public string PasswordHash { get; set; } = passwordHash;
}