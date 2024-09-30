using MongoDB.Bson.Serialization.Attributes;

namespace BookaDesk.UserService.Infrastructure.Models;

public class UserDbModel(string email, string password) : DbEntity
{
    [BsonElement("Email")]
    public string Email { get; set; } = email;

    [BsonElement("Password")]
    public string Password { get; set; } = password;
}