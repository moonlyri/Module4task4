namespace Module4task4;

public class OrdersEntity
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string CustomerId { get; set; }
    public int OrderNumber { get; set; }
    public int PaymentId { get; set; }
    public ShippersEntity Shippers { get; set; }
    public ShippersEntity ShippersId { get; set; }
    public PaymentEntity Payment { get; set; }
    public CustomersEntity Customers { get; set; }
    public List<OrderDetailsEntity> OrderDetails { get; set; }
}