namespace Module4task4.Models;

public class OrderDetails
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string OrderDetailId { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
    public int ProductId { get; set; }
}