using System.Collections.Generic;

namespace Module4task4;

public class CustomersEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string FullName { get; set; }
    public string City { get; set; }
    public List<OrdersEntity> Orders { get; set; }
}