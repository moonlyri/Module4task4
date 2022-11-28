using Microsoft.EntityFrameworkCore;
using Module4task4.EntityConfig;

namespace Module4task4;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CategoryEntity> Categories { get; set; } 
    public DbSet<CustomersEntity> Customers { get; set; } 
    public DbSet<OrdersEntity> Orders { get; set; } 
    public DbSet<OrderDetailsEntity> OrderDetails { get; set; } 
    
    public DbSet<PaymentEntity> Payments { get; set; } 
    public DbSet<ProductsEntity> Products { get; set; } = null!;
    public DbSet<ShippersEntity> Shippers { get; set; } = null!;
    public DbSet<SuppliersEntity> Suppliers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryEntityConfig());
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