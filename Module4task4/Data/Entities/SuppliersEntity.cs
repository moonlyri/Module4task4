using System.Collections.Generic;

namespace Module4task4;

public class SuppliersEntity
{
   public int Id { get; set; }
   public int? SupplierId { get; set; } = null!;
   public string CompanyName { get; set; } = null!;
   public string ContactFullname { get; set; } = null!;
   public string City { get; set; } = null!;
   public List<ProductsEntity> Products { get; set; } = null!;
}