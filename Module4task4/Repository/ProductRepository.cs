using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> AddProductAsync(string name, string description, int size, string color)
    {
        var product = new ProductsEntity()
        {
            ProductName = name,
            ProductDescription = description,
            Size = size,
            Color = color
        };

        var result = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<ProductsEntity?> GetProductAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
    }
}