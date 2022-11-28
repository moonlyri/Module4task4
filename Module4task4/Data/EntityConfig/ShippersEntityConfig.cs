using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class ShippersEntityConfig : IEntityTypeConfiguration<ShippersEntity>
{
    public void Configure(EntityTypeBuilder<ShippersEntity> builder)
    {
        builder.ToTable("Id").HasKey(s => s.Id);

        builder.Property(s => s.ShippersId).HasColumnName("ShippersId").IsRequired().ValueGeneratedOnAdd();
        builder.Property(s => s.Phone).IsRequired().HasColumnName("Phone");
        builder.Property(s => s.CompanyName).HasColumnName("CompanyName").IsRequired();
    }
}