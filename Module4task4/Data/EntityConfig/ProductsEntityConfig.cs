using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.Data.EntityConfig;

public class ProductsEntityConfig : IEntityTypeConfiguration<ProductsEntity>
{
    public void Configure(EntityTypeBuilder<ProductsEntity> build)
    {
        build.HasKey(p => p.ProductId);
        build.Property(p => p.ProductId).HasColumnName("ProductId");
        build.Property(p => p.ProductDescription).HasColumnName("ProductDescription");
        build.Property(p => p.ProductName).HasColumnName("ProductName").IsRequired();
        build.Property(p => p.Price).HasColumnName("Price").IsRequired();
        build.HasOne(s => s.Suppliers)
            .WithMany(p => p.Products)
            .HasForeignKey(s => s.SuppliersId)
            .OnDelete(DeleteBehavior.Cascade);
        build.HasOne(h => h.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}