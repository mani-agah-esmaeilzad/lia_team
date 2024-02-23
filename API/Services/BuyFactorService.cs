namespace API.Services;
public class BuyFactorService
{
    private readonly IMongoCollection<BuyFactor> _BuyFactorollection;
    private readonly IMongoCollection<Product> _Productcollection;

    public BuyFactorService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _BuyFactorollection = database.GetCollection<BuyFactor>("buyFactors");

        MongoClient clientPro = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase databasePro = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _Productcollection = database.GetCollection<Product>("products");

    }

    public async Task<List<BuyFactor>> GetBuyFactorsAsync()
    {
        return await _BuyFactorollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<BuyFactor> GetBuyFactorDetailsAsync(string id)
    {
        return await _BuyFactorollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task DeleteBuyFactorAsync(string id)
    {
        FilterDefinition<BuyFactor> buyFactor = Builders<BuyFactor>.Filter.Eq("Id", id);
        await _BuyFactorollection.DeleteOneAsync(buyFactor);
    }

    public async Task CreateBuyFactorAsync(BuyFactor buyfactor)
    {
        foreach (var item in buyfactor.products)
        {
            findProductSetData(item);
        }
        await _BuyFactorollection.InsertOneAsync(buyfactor);
    }
    public async void findProductSetData(productFactors products)
    {
        FilterDefinition<Product> product = Builders<Product>.Filter.Eq("Id", products.ProductId);
        var productOld = _Productcollection.Find(x => x.Id == products.ProductId).FirstOrDefaultAsync();

        UpdateDefinition<Product> update = Builders<Product>.Update.Set("count", (productOld.Result.Count + products.quantity));
        await _Productcollection.UpdateOneAsync(product, update);

        UpdateDefinition<Product> up = Builders<Product>.Update.Set("buyPrice", (products.price));
        await _Productcollection.UpdateOneAsync(product, up);

    }
    public async Task update(BuyFactor product, DateTime buyTime, productFactors[] productFactors, double totalPrice)
    {
        FilterDefinition<BuyFactor> filter = Builders<BuyFactor>.Filter.Eq("Id", product.Id);
        BuyFactor replaceProduct = new BuyFactor
        {
            BuyTime = buyTime,
            products = productFactors,
            TotalPrice = totalPrice
        };
        await _BuyFactorollection.ReplaceOneAsync(filter, replaceProduct);
    }
}
