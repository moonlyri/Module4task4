using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class CustomerEntityConfig : IEntityTypeConfiguration<CustomersEntity>
{
    public void Configure(EntityTypeBuilder<CustomersEntity> builder)
    {
        builder.ToTable("Id").HasKey(c => c.Id);
        builder.Property(c => c.CustomerId).HasColumnName("CustomerId").IsRequired().ValueGeneratedOnAdd();
        builder.Property(c => c.City).HasColumnName("City").IsRequired();
        builder.Property(c => c.FullName).HasColumnName("FirstName").IsRequired();
        
    }

}