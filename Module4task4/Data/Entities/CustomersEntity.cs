namespace Module4task4;

public class CustomersEntity
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public string FullName { get; set; }
    public string City { get; set; }
    public List<OrdersEntity> Orders { get; set; }
}