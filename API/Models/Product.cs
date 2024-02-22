namespace API.Models;
public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("barcode")]
    public string BarCode { get; set; } = null!;
    [BsonElement("sellPrice")]
    public int SellPrice { get; set; }
    [BsonElement("buyPrice")]
    public int BuyPrice { get; set; }
    [BsonElement("count")]
    public int Count { get; set; }
    [BsonElement("pv")]
    public string PV { get; set; }
    [BsonElement("category")]
    public Category Category { get; set; } = null!;
}
