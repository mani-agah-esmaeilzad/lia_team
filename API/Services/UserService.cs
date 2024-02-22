namespace API.Services;
public class UserService
{
    private readonly IMongoCollection<User> _usersCollection;
    public UserService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _usersCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
    }
    public async Task CreateUsersAsync(User user)
    {
        await _usersCollection.InsertOneAsync(user);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _usersCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<User> LoginUsersAsync(string number,string password)
    {
        return await _usersCollection.Find(x=>x.Number == number && x.Password == password).FirstOrDefaultAsync();
    }

    public async Task DeleteUsersAsync(string id)
    {
        FilterDefinition<User> user = Builders<User>.Filter.Eq("Id",id);
        await _usersCollection.DeleteOneAsync(user);
    }
}