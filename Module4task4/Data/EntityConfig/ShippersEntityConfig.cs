using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class ShippersEntityConfig : IEntityTypeConfiguration<ShippersEntity>
{
    public void Configure(EntityTypeBuilder<ShippersEntity> build)
    {
        build.ToTable("Id").HasKey(s => s.Id);
        build.Property(s => s.ShippersId).HasColumnName("ShippersId").IsRequired();
        build.Property(s => s.Phone).IsRequired().HasColumnName("Phone");
        build.Property(s => s.CompanyName).HasColumnName("CompanyName").IsRequired();
        build.HasMany(s => s.Orders).WithOne(o => o.Shippers)
            .HasForeignKey(o => o.ShippersId).IsRequired();
    }
}