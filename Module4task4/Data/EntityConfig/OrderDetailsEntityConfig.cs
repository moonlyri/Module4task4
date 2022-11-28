using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class OrderDetailsEntityConfig : IEntityTypeConfiguration<OrderDetailsEntity>
{
    public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
    {
        builder.ToTable("Id").HasKey(o => o.Id);
        builder.Property(o => o.OrderDetailId).HasColumnName("OrderDetailId").IsRequired().ValueGeneratedOnAdd();
        builder.Property(o => o.Color).HasColumnName("Color").IsRequired();
        builder.Property(o => o.Price).HasColumnName("Price").IsRequired();
        builder.Property(o => o.OrderId).HasColumnName("OrderId").IsRequired();
        
        builder.HasOne(p => p.Products)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.Orders)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}