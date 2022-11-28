namespace Module4task4.Models;

public class Orders
{
    public IEnumerable<OrderDetailsEntity> OrderDetails { get; set; }
    public int CustomerId { get; set; }
}