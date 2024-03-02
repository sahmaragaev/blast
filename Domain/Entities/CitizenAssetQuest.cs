using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

[BsonIgnoreExtraElements]
public class CitizenAssetQuest
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    [BsonElement("citizen")] public string CitizenId { get; set; }

    [BsonElement("asset")] public Asset Asset { get; set; }

    [BsonElement("task")] public Quest Quest { get; set; }
}