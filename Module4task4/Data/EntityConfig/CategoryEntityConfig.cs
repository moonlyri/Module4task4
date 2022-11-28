using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Module4task4.EntityConfig;

public class CategoryEntityConfig : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Category").HasKey(c => c.Id);
        builder.Property(c => c.CategoryId).IsRequired().HasColumnName("CategoryId").ValueGeneratedOnAdd();
        builder.Property(c => c.Description).IsRequired().HasColumnName("Description");
        builder.Property(c => c.CategoryName).IsRequired().HasColumnName("CategoryName");
    }
}