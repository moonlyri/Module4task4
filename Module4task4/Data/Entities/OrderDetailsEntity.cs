using Module4task4.Models;

namespace Module4task4;

public class OrderDetailsEntity
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string OrderDetailId { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
    public int ProductId { get; set; }
    public Product Products { get; set; }
    public OrdersEntity Orders { get; set; }
    
}