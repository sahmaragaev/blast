using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

[BsonIgnoreExtraElements]
public class Quest
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string Id { get; set; }
    
    [BsonElement("title")] public string Title { get; set; }

    [BsonElement("description")] public string Description { get; set; }
}