using System.Collections.Generic;
using Module4task4.Models;

namespace Module4task4;

public class OrdersEntity
{
    public int Id { get; set; }
    public int? OrderId { get; set; }
    public int? CustomerId { get; set; }
    public int? OrderNumber { get; set; }
    public int? PaymentId { get; set; }
    public decimal? Price { get; set; }
    public ShippersEntity? Shippers { get; set; }
    public int? ShippersId { get; set; }
    public PaymentEntity? Payments { get; set; }
    public CustomersEntity? Customers { get; set; }
    public List<OrderDetailsEntity>? OrderDetails { get; set; }
}