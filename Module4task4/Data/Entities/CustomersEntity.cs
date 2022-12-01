using System.Collections.Generic;

namespace Module4task4;

public class CustomersEntity
{
    public int Id { get; set; }
    public int? CustomerId { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string City { get; set; } = null!;
    public List<OrdersEntity> Orders { get; set; } = null!;
}