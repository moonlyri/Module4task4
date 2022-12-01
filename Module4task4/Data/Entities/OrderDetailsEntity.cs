using Module4task4.Models;

namespace Module4task4;

public class OrderDetailsEntity
{
    public int Id { get; set; }
    public int? OrderId { get; set; }
    public int? OrderDetailId { get; set; } = null!;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public int? ProductId { get; set; }
    public Product Products { get; set; } = null!;
    public OrdersEntity Orders { get; set; } = null!;
}