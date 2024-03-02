using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

[BsonIgnoreExtraElements]
public class Citizen
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string Id { get; set; }

    [BsonElement("firstName")] public string FirstName { get; set; }

    [BsonElement("lastName")] public string LastName { get; set; }

    [BsonElement("birthDate")] public DateTime BirthDate { get; set; }

    [BsonElement("fin")] public string Pin { get; set; }
}