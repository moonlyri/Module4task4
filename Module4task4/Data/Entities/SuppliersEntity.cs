using System.Collections.Generic;

namespace Module4task4;

public class SuppliersEntity
{
   public int Id { get; set; }
    public int SupplierId { get; set; }
    public string CompanyName { get; set; }
    public string ContactFullname { get; set; }
    public string City { get; set; }
    public List<ProductsEntity> Products { get; set; }
}