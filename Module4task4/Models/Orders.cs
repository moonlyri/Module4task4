using System.Collections.Generic;

namespace Module4task4.Models;

public class Orders
{
    public List<OrderDetails> OrderDetails { get; set; } = null!;
    public int CustomerId { get; set; }
}