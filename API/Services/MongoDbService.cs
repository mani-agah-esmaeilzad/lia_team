using Microsoft.Extensions.Options;

namespace API.Services;
public class MongoDbService
{
    private readonly IMongoCollection<User> _usersCollection;
    public MongoDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
     MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
     IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
     _usersCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);   
    }
}