using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.Data.EntityConfig;

public class PaymentEntityConfig : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> build)
    {
        build.HasKey(p => p.PaymentId);
        build.Property(p => p.PaymentId).HasColumnName("PaymentId");
        build.Property(p => p.Allowed).HasColumnName("Allowed");
        build.Property(p => p.PaymentType).HasColumnName("PaymentType");
        build.HasMany(p => p.Orders).WithOne(o => o.Payments)
            .HasForeignKey(o => o.PaymentId);
    }
}