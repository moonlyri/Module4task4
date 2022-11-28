using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class PaymentEntityConfig : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        builder.ToTable("Id").HasKey(p => p.Id);
        builder.Property(p => p.PaymentId).HasColumnName("PaymentId").IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.Allowed).HasColumnName("Allowed").IsRequired();
        builder.Property(p => p.PaymentType).HasColumnName("PaymentType").IsRequired();
    }
}