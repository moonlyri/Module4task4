using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class SuppliersEntityConfig : IEntityTypeConfiguration<SuppliersEntity>
{
    public void Configure(EntityTypeBuilder<SuppliersEntity> builder)
    {
        builder.ToTable("Id").HasKey(s => s.Id);

        builder.Property(s => s.SupplierId).HasColumnName("SupplierId").IsRequired().ValueGeneratedOnAdd();
        builder.Property(s => s.City).HasColumnName("City").IsRequired();
        builder.Property(s => s.CompanyName).HasColumnName("CompanyName").IsRequired();
        builder.Property(s => s.ContactFullname).HasColumnName("ContactFullName").IsRequired();
    }


}