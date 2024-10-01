using MongoDB.Bson.Serialization.Attributes;

namespace BookaDesk.UserService.Infrastructure.Models;

public class UserDbModel(string email, string passwordHash) : DbEntity
{
    [BsonElement("Email")]
    public string Email { get; set; } = email;

    [BsonElement("PasswordHash")]
    public string PasswordHash { get; set; } = passwordHash;
}