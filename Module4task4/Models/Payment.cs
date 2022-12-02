using System.Collections.Generic;

namespace Module4task4.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public string? PaymentType { get; set; }
    public IEnumerable<Orders>? Orders { get; set; }
}