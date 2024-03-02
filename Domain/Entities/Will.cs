using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

[BsonIgnoreExtraElements]
public class Will
{
    [BsonElement("grantor")] public Account Grantor { get; set; }

    [BsonElement("citizenAssets")] public List<CitizenAssetTask> CitizenAssets { get; set; }
}