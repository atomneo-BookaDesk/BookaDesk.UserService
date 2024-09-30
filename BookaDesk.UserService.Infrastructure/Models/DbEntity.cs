using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookaDesk.UserService.Infrastructure.Models;

public class DbEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
}