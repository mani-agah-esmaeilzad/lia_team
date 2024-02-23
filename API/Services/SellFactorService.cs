namespace API.Services;
public class SellFactorService
{
    private readonly IMongoCollection<SellFactor> _SellFactorollection;
    private readonly IMongoCollection<Product> _Productcollection;

    public SellFactorService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _SellFactorollection = database.GetCollection<SellFactor>("sellFactors");

        MongoClient clientPro = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase databasePro = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _Productcollection = database.GetCollection<Product>("products");
    }

    public async Task<List<SellFactor>> GetSellFactorsAsync()
    {
        return await _SellFactorollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<SellFactor> GetSellFactorDetailsAsync(string id)
    {
        return await _SellFactorollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task DeleteSellFactorAsync(string id)
    {
        FilterDefinition<SellFactor> SellFactor = Builders<SellFactor>.Filter.Eq("Id", id);
        await _SellFactorollection.DeleteOneAsync(SellFactor);
    }

    public async Task CreateSellFactorAsync(SellFactor sellFactor)
    {
        foreach (var item in sellFactor.Products)
        {
            findProductSetData(item);
        }
        await _SellFactorollection.InsertOneAsync(sellFactor);
    }

    public async void findProductSetData(productFactors products)
    {
        FilterDefinition<Product> product = Builders<Product>.Filter.Eq("Id", products.ProductId);
        var productOld = _Productcollection.Find(x => x.Id == products.ProductId).FirstOrDefaultAsync();

        UpdateDefinition<Product> update = Builders<Product>.Update.Set("count", (productOld.Result.Count - products.quantity));
        await _Productcollection.UpdateOneAsync(product, update);
    }

    public async Task update(SellFactor sellFactor, string user, productFactors[] productFactors, double offer, DateTime dates, double totalPrice, bool statusPayment, string description, string satisfaction)
    {
        FilterDefinition<SellFactor> filter = Builders<SellFactor>.Filter.Eq("Id", sellFactor.Id);
        SellFactor replaceProduct = new SellFactor
        {
            User = user,
            Products = productFactors,
            Offer = offer,
            SellDate = dates,
            TotalPrice = totalPrice,
            StatusPayment = statusPayment,
            Description = description,
            satisfaction = satisfaction
        };
        await _SellFactorollection.ReplaceOneAsync(filter, replaceProduct);
    }
}
