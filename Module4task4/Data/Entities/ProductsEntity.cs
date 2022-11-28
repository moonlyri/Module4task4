namespace Module4task4;

public class ProductsEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int Size { get; set; }
    public string Color { get; set; }
    public CategoryEntity CategoryId { get; set; }
    public SuppliersEntity SuppliersId { get; set; }
    public SuppliersEntity Suppliers { get; set; }
    public CategoryEntity Category { get; set; }
    public List<OrderDetailsEntity> OrderDetails { get; set; }
}