using MongoDB.Driver;

namespace testingMongoLocal.Services;

public class MongoDbService
{
    public IMongoDatabase Database { get; }

    public MongoDbService(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDb:ConnectionString"]);
        Database = client.GetDatabase(config["MongoDb:DatabaseName"]);
    }
}