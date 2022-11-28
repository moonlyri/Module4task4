using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class ProductsEntityConfig : IEntityTypeConfiguration<ProductsEntity>
{
    public void Configure(EntityTypeBuilder<ProductsEntity> builder)
    {
        builder.ToTable("Id").HasKey(p => p.Id);
        
        builder.Property(p => p.ProductId).HasColumnName("ProductId").IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.ProductDescription).HasColumnName("ProductDescription").IsRequired();
        builder.Property(p => p.ProductName).HasColumnName("ProductName").IsRequired();
        builder.Property(p => p.Color).HasColumnName("Color").IsRequired();
        builder.Property(p => p.Size).HasColumnName("Size").IsRequired();

        builder.HasOne(c => c.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Suppliers)
            .WithMany(p => p.Products)
            .HasForeignKey(s => s.SuppliersId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}