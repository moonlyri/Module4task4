using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.Data.EntityConfig;

public class CustomerEntityConfig : IEntityTypeConfiguration<CustomersEntity>
{
    public void Configure(EntityTypeBuilder<CustomersEntity> build)
    {
        build.ToTable("CustomerId").HasKey(c => c.CustomerId);
        build.Property(c => c.CustomerId).HasColumnName("CustomerId").IsRequired();
        build.Property(c => c.City).HasColumnName("City");
        build.Property(c => c.FullName).HasColumnName("FirstName").IsRequired();
    }
}