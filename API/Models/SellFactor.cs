namespace API.Models;
public class SellFactor
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string User { get; set; } = null!;
    public productFactors[] Products { get; set; } = null!;
    public double Offer { get; set; }
    public DateTime SellDate { get; set; }
    public double TotalPrice { get; set; }
    public bool StatusPayment { get; set; }
    public string Description { get; set; } = null!;
    public string satisfaction { get; set; } = null!;
}