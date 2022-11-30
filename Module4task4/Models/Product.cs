using System.Collections.Generic;

namespace Module4task4.Models;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int Size { get; set; }
    public string Color { get; set; }
    public IEnumerable<OrderDetailsEntity>? OrderDetails { get; set; }
}