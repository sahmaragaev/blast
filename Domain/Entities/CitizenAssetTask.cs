using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

[BsonIgnoreExtraElements]
public class CitizenAssetTask
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string Id { get; set; }

    [BsonElement("citizen")] public Citizen Citizen { get; set; }

    [BsonElement("asset")] public Asset Asset { get; set; }

    [BsonElement("task")] public Task Task { get; set; }
}