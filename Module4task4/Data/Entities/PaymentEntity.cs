using System.Collections.Generic;

namespace Module4task4;

public class PaymentEntity
{
    public int Id { get; set; }
    public int? PaymentId { get; set; } = null!;
    public string PaymentType { get; set; } = null!;
    public string Allowed { get; set; } = null!;
    public List<OrdersEntity> Orders { get; set; } = null!;
}