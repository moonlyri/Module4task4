using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class OrdersEntityConfig : IEntityTypeConfiguration<OrdersEntity>
{
    public void Configure(EntityTypeBuilder<OrdersEntity> builder)
    {
        builder.ToTable("Id").HasKey(o => o.Id);
        
        builder.Property(o => o.OrderId).HasColumnName("OrderId").IsRequired().ValueGeneratedOnAdd();
        builder.Property(o => o.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(o => o.OrderNumber).HasColumnName("OrderNumber").IsRequired();
        builder.Property(o => o.PaymentId).HasColumnName("PaymentId").IsRequired();
        
        builder.HasOne(o => o.Customers)
            .WithMany(o => o.Orders)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Payment)
            .WithMany(o => o.Orders)
            .HasForeignKey(p => p.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Shippers)
            .WithMany(o => o.Orders)
            .HasForeignKey(s => s.ShippersId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}