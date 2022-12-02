using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.Data.EntityConfig;

public class ShippersEntityConfig : IEntityTypeConfiguration<ShippersEntity>
{
    public void Configure(EntityTypeBuilder<ShippersEntity> build)
    {
        build.HasKey(s => s.ShippersId);
        build.Property(s => s.ShippersId).HasColumnName("ShippersId");
        build.Property(s => s.Phone).IsRequired().HasColumnName("Phone");
        build.Property(s => s.CompanyName).HasColumnName("CompanyName");
        build.HasMany(s => s.Orders).WithOne(o => o.Shippers)
            .HasForeignKey(o => o.ShippersId).IsRequired();
    }
}