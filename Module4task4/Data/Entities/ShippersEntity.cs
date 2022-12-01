using System.Collections.Generic;

namespace Module4task4;

public class ShippersEntity
{
    public int Id { get; set; }
    public int? ShippersId { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public int? Phone { get; set; } = null!;
    public List<OrdersEntity> Orders { get; set; } = null!;
}