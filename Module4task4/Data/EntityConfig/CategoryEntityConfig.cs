using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Module4task4.EntityConfig;

public class CategoryEntityConfig : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> build)
    {
        build.ToTable("Category").HasKey(c => c.Id);
        build.Property(c => c.CategoryId).HasColumnName("CategoryId");
        build.Property(c => c.Description).HasColumnName("Description");
        build.Property(c => c.CategoryName).HasColumnName("CategoryName");
        build.HasMany(c => c.Products).WithOne(p => p.Category)
            .HasForeignKey(c => c.CategoryId);
    }
}