using System.Collections.Generic;

namespace Module4task4;

public class CategoryEntity
{
    public int Id { get; set; }
    public int? CategoryId { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<ProductsEntity> Products { get; set; } = null!;
}