namespace API.Models;
public class BuyFactor
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public productFactors[] products { get; set; } = null!;
    public DateTime BuyTime { get; set; }
    public double TotalPrice { get; set; }
}