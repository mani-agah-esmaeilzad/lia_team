namespace Client.Models;
public class BuyFactor
{
    public string? Id { get; set; }
    public productFactors[] products { get; set; } = null!;
    public DateTime BuyTime { get; set; }
    public double TotalPrice { get; set; }
}