using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class SuppliersEntityConfig : IEntityTypeConfiguration<SuppliersEntity>
{
    public void Configure(EntityTypeBuilder<SuppliersEntity> build)
    {
        build.ToTable("Id").HasKey(s => s.Id);
        build.Property(s => s.SupplierId).HasColumnName("SupplierId").IsRequired();
        build.Property(s => s.City).HasColumnName("City").IsRequired();
        build.Property(s => s.CompanyName).HasColumnName("CompanyName").IsRequired();
        build.Property(s => s.ContactFullname).HasColumnName("ContactFullName").IsRequired();
        build.HasMany(p => p.Products).WithOne(s => s.Suppliers)
            .HasForeignKey(s => s.SuppliersId).IsRequired();
    }


}