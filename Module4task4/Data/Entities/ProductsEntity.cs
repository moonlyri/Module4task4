using System.Collections.Generic;

namespace Module4task4;

public class ProductsEntity
{
    public int Id { get; set; }
    public int? ProductId { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public decimal Price { get; set; }
    public CategoryEntity CategoryId { get; set; } = null!;
    public SuppliersEntity SuppliersId { get; set; } = null!;
    public SuppliersEntity Suppliers { get; set; } = null!;
    public CategoryEntity Category { get; set; } = null!;
    public List<OrderDetailsEntity> OrderDetails { get; set; } = null!;
}