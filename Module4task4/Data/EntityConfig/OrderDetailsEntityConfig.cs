using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class OrderDetailsEntityConfig : IEntityTypeConfiguration<OrderDetailsEntity>
{
    public void Configure(EntityTypeBuilder<OrderDetailsEntity> build)
    {
        build.HasKey(o => o.OrderDetailId);
        build.Property(o => o.OrderDetailId).HasColumnName("OrderDetailId");
        build.Property(o => o.Price).HasColumnName("Price").IsRequired();
        build.Property(o => o.OrderId).HasColumnName("OrderId");
        build.Property(o => o.Count).HasColumnName("Count");
        build.HasOne(p => p.Products)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        build.HasOne(o => o.Orders)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}