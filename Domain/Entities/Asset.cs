using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

[BsonIgnoreExtraElements]
public class Asset
{
    [BsonElement("name")] public string Name { get; set; }

    [BsonElement("value")] public decimal Value { get; set; }

    [BsonElement("assetType")] public AssetType AssetType { get; set; }
}

public enum AssetType
{
    Monetary,
    Property
}