using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class SuppliersEntityConfig : IEntityTypeConfiguration<SuppliersEntity>
{
    public void Configure(EntityTypeBuilder<SuppliersEntity> build)
    {
        build.HasKey(s => s.SupplierId);
        build.Property(s => s.SupplierId).HasColumnName("SupplierId");
        build.Property(s => s.City).HasColumnName("City");
        build.Property(s => s.CompanyName).HasColumnName("CompanyName");
        build.Property(s => s.ContactFullname).HasColumnName("ContactFullName");
        build.HasMany(p => p.Products).WithOne(s => s.Suppliers)
            .HasForeignKey(s => s.SuppliersId);
    }
}