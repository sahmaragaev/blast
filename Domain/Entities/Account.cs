using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

[BsonIgnoreExtraElements]
public class Account
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string Id { get; set; }

    [BsonElement("citizenId")] public string CitizenId { get; set; }

    [BsonElement("password")] public string Password { get; set; }

    [BsonElement("trustees")] public List<Citizen>? Trustees { get; set; }

    [BsonElement("grantors")] public List<Citizen>? Grantors { get; set; }

    [BsonElement("wills")] public List<Will>? Wills { get; set; }

    [BsonElement("finalWill")] public Will? FinalWill { get; set; }

    [BsonElement("assets")] public List<Asset>? Assets { get; set; }
}