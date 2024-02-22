namespace API.Services;
public class ProductService
{
    private readonly IMongoCollection<Product> _ProductsCollection;
    public ProductService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _ProductsCollection = database.GetCollection<Product>("products");
    }

    public async Task CreateProductAsync(Product product)
    {
        await _ProductsCollection.InsertOneAsync(product);
    }
    
    public async Task<List<Product>> GetProductAsync()
    {
        return await _ProductsCollection.Find(new BsonDocument()).ToListAsync();
    }

       public async Task<Product> getProductDetailsAsync(string id)
    {
        return await _ProductsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task DeleteProductAsync(string id)
    {
        FilterDefinition<Product> product = Builders<Product>.Filter.Eq("Id",id);
        await _ProductsCollection.DeleteOneAsync(product);
    }

    public async Task UpdateProductAsync(Product product,string name,string barcode,int sellPrice,int BuyPrice,int count,string pv,string category)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("Id",product.Id);
        Product replaceProduct = new Product();
        replaceProduct.Name = name;
        replaceProduct.BarCode = barcode;
        replaceProduct.SellPrice = sellPrice;
        replaceProduct.BuyPrice = BuyPrice;
        replaceProduct.Count = count;
        replaceProduct.PV = pv;
        replaceProduct.Category = category;
        replaceProduct.Id = product.Id;
        await _ProductsCollection.ReplaceOneAsync(filter,replaceProduct);
    }
    
}