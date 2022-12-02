using System.Collections.Generic;

namespace Module4task4.Models;

public class Orders
{
    public IEnumerable<OrderDetails> OrderDetails { get; set; } = null!;
    public int? OrderId { get; set; }
    public int? PaymentId { get; set; }
    public int? ShippersId { get; set; }
    public int? CustomerId { get; set; }

    public int Id { get; set; }
}