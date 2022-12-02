namespace Module4task4.Models;

public class OrderDetails
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? OrderDetailId { get; set; }
    public int? Count { get; set; }

    public decimal? Price { get; set; }

    public int? ProductId { get; set; }
    public Product? Products { get; set; }
}