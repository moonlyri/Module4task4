using System.Collections.Generic;

namespace Module4task4;

public class CategoryEntity
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public bool? Active { get; set; }
    public List<ProductsEntity>? Products { get; set; }
}