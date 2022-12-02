using System.Collections.Generic;

namespace Module4task4.Models;

public class Supplier
{
    public int SupplierId { get; set; }
    public string? ContactFName { get; set; }
    public string? CompanyName { get; set; }
    public string? City { get; set; }
    public IEnumerable<Product>? Products { get; set; }
}