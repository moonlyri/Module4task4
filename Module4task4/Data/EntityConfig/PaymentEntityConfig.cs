using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class PaymentEntityConfig : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> build)
    {
        build.ToTable("Id").HasKey(p => p.Id);
        build.Property(p => p.PaymentId).HasColumnName("PaymentId");
        build.Property(p => p.Allowed).HasColumnName("Allowed");
        build.Property(p => p.PaymentType).HasColumnName("PaymentType");
        build.HasMany(p => p.Orders).WithOne(o => o.Payment)
            .HasForeignKey(o => o.PaymentId);
    }
}