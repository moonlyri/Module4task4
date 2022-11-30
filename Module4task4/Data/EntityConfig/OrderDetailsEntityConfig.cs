using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class OrderDetailsEntityConfig : IEntityTypeConfiguration<OrderDetailsEntity>
{
    public void Configure(EntityTypeBuilder<OrderDetailsEntity> build)
    {
        build.ToTable("Id").HasKey(o => o.Id);
        build.Property(o => o.OrderDetailId).HasColumnName("OrderDetailId").IsRequired();
        build.Property(o => o.Color).HasColumnName("Color").IsRequired();
        build.Property(o => o.Price).HasColumnName("Price").IsRequired();
        build.Property(o => o.OrderId).HasColumnName("OrderId").IsRequired();
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