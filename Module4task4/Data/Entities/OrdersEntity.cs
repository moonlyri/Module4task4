using System.Collections.Generic;
using Module4task4.Models;

namespace Module4task4;

public class OrdersEntity
{
    public int Id { get; set; }
    public int? OrderId { get; set; } = null!;
    public int? CustomerId { get; set; } = null!;
    public int? OrderNumber { get; set; } = null!;
    public int? PaymentId { get; set; } = null!;
    public decimal Price { get; set; }
    public ShippersEntity Shippers { get; set; } = null!;
    public ShippersEntity ShippersId { get; set; } = null!;
    public PaymentEntity Payment { get; set; } = null!;
    public CustomersEntity Customers { get; set; } = null!;
    public List<OrderDetailsEntity> OrderDetails { get; set; } = null!;
}