using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task4.EntityConfig;

public class CustomerEntityConfig : IEntityTypeConfiguration<CustomersEntity>
{
    public void Configure(EntityTypeBuilder<CustomersEntity> build)
    {
        build.ToTable("Id").HasKey(c => c.Id);
        build.Property(c => c.CustomerId).HasColumnName("CustomerId").IsRequired();
        build.Property(c => c.City).HasColumnName("City").IsRequired();
        build.Property(c => c.FullName).HasColumnName("FirstName").IsRequired();
        build.HasMany(c => c.Orders).WithOne(o => o.Customers)
            .HasForeignKey(c => c.CustomerId).IsRequired();
    }

}