using System.Collections.Generic;

namespace Module4task4.Models;

public class Shipper
{
    public int ShipperId { get; set; }
    public string? CompanyName { get; set; }
    public IEnumerable<Orders>? Orders { get; set; } = new List<Orders>();
}