using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class OrdersEntityConfig : IEntityTypeConfiguration<OrdersEntity>
{
    public void Configure(EntityTypeBuilder<OrdersEntity> build)
    {
        build.HasKey(o => o.OrderId);
        build.Property(o => o.OrderId).HasColumnName("OrderId");
        build.Property(o => o.CustomerId).HasColumnName("CustomerId");
        build.Property(o => o.OrderNumber).HasColumnName("OrderNumber");
        build.Property(o => o.PaymentId).HasColumnName("PaymentId");
        build.Property(o => o.Price).HasColumnName("Price").IsRequired();
        build.HasOne(h => h.Customers)
            .WithMany(w => w.Orders)
            .HasForeignKey(h => h.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        build.HasOne(h => h.Payments)
            .WithMany(w => w.Orders)
            .HasForeignKey(h => h.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        build.HasOne(h => h.Shippers)
            .WithMany(w => w.Orders)
            .HasForeignKey(h => h.ShippersId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}