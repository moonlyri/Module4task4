using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class OrdersEntityConfig : IEntityTypeConfiguration<OrdersEntity>
{
    public void Configure(EntityTypeBuilder<OrdersEntity> build)
    {
        build.ToTable("Id").HasKey(o => o.Id);
        build.Property(o => o.OrderId).HasColumnName("OrderId").IsRequired().ValueGeneratedOnAdd();
        build.Property(o => o.CustomerId).HasColumnName("CustomerId").IsRequired();
        build.Property(o => o.OrderNumber).HasColumnName("OrderNumber").IsRequired();
        build.Property(o => o.PaymentId).HasColumnName("PaymentId").IsRequired();
        build.HasOne(o => o.Customers)
            .WithMany(o => o.Orders)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
        build.HasOne(p => p.Payment)
            .WithMany(o => o.Orders)
            .HasForeignKey(p => p.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);
        build.HasOne(s => s.Shippers)
            .WithMany(o => o.Orders)
            .HasForeignKey(s => s.ShippersId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}