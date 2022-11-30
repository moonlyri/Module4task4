using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class ProductsEntityConfig : IEntityTypeConfiguration<ProductsEntity>
{
    public void Configure(EntityTypeBuilder<ProductsEntity> build)
    {
        build.ToTable("Id").HasKey(p => p.Id);
        build.Property(p => p.ProductId).HasColumnName("ProductId").IsRequired();
        build.Property(p => p.ProductDescription).HasColumnName("ProductDescription").IsRequired();
        build.Property(p => p.ProductName).HasColumnName("ProductName").IsRequired();
        build.Property(p => p.Color).HasColumnName("Color").IsRequired();
        build.Property(p => p.Size).HasColumnName("Size").IsRequired();
        build.HasOne(c => c.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        build.HasOne(s => s.Suppliers)
            .WithMany(p => p.Products)
            .HasForeignKey(s => s.SuppliersId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}