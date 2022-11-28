namespace Module4task4;

public class PaymentEntity
{
    public int Id { get; set; }
    public int PaymentId { get; set; }
    public string PaymentType { get; set; }
    public string Allowed { get; set; }
    public List<OrdersEntity> Orders { get; set; }
}