using System.Collections.Generic;

namespace Module4task4;

public class ShippersEntity
{
    public int Id { get; set; }
    public int? ShippersId { get; set; }
    public string? CompanyName { get; set; }
    public int? Phone { get; set; }
    public List<OrdersEntity>? Orders { get; set; }
}