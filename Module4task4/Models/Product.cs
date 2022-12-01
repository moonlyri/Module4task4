#nullable enable
using System.Collections.Generic;

namespace Module4task4.Models;

public class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public decimal Price { get; set; }
    public int Count { get; set; }

    public IEnumerable<OrderDetailsEntity>? OrderDetails { get; set; }
}