using Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Database.DbContexts;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(MongoDbSettings? settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    // public IMongoCollection<Apartment> Apartments => _database.GetCollection<Apartment>("apartments");
}