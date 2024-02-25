namespace Client.Models;
public class Product
{
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public string BarCode { get; set; } = null!;
    public int SellPrice { get; set; }
    public int BuyPrice { get; set; }
    public int Count { get; set; }
    public string PV { get; set; } = null!;
    public Category Category { get; set; } = null!;
}
public class productFactors
{
public string ProductId { get; set; } = null!;
public int quantity { get; set; }
public double price { get; set; }
}