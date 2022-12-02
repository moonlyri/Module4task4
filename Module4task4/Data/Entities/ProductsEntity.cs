using System.Collections.Generic;

namespace Module4task4;

public class ProductsEntity
{
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal? Price { get; set; }
    public int? SuppliersId { get; set; }
    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    public SuppliersEntity? Suppliers { get; set; }
    public List<OrderDetailsEntity>? OrderDetails { get; set; }
}