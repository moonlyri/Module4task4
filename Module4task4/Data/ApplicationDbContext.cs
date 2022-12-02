using Microsoft.EntityFrameworkCore;
using Module4task4.Data.EntityConfig;

namespace Module4task4.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CustomersEntity> Customers { get; set; } = null!;

    public DbSet<OrdersEntity> Orders { get; set; } = null!;

    public DbSet<OrderDetailsEntity> OrderDetails { get; set; } = null!;

    public DbSet<PaymentEntity> Payments { get; set; } = null!;

    public DbSet<ProductsEntity> Products { get; set; } = null!;

    public DbSet<ShippersEntity> Shippers { get; set; } = null!;

    public DbSet<SuppliersEntity> Suppliers { get; set; } = null!;

    public DbSet<CategoryEntity> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerEntityConfig());
        modelBuilder.ApplyConfiguration(new OrderDetailsEntityConfig());
        modelBuilder.ApplyConfiguration(new OrdersEntityConfig());
        modelBuilder.ApplyConfiguration(new PaymentEntityConfig());
        modelBuilder.ApplyConfiguration(new ProductsEntityConfig());
        modelBuilder.ApplyConfiguration(new ShippersEntityConfig());
        modelBuilder.ApplyConfiguration(new SuppliersEntityConfig());
        modelBuilder.UseHiLo();
    }
}