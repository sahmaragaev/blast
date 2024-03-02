using Configuration;
using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Database.DbContexts;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<Account> Accounts => _database.GetCollection<Account>("accounts");
    public IMongoCollection<Citizen> Citizens => _database.GetCollection<Citizen>("citizen");
    public IMongoCollection<CitizenAssetQuest> CitizenAssetTasks => _database.GetCollection<CitizenAssetQuest>("citizenAssetTasks");
    public IMongoCollection<Quest> Quests => _database.GetCollection<Quest>("quests");
}