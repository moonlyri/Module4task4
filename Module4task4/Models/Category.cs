using System.Collections.Generic;

namespace Module4task4.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public IEnumerable<Product>? Products { get; set; } = new List<Product>();
}