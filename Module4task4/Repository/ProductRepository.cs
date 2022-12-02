using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;

namespace Module4task4.Repository;

public class ProductRepository : BaseRepository, IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<int> AddProductAsync(string name, decimal price)
    {
        var product = new ProductsEntity()
        {
            ProductName = name,
            Price = price
        };

        var result = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<ProductsEntity?> GetProductAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<bool> UpdatePrice(int id, decimal price)
    {
        var entity = await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
        if (entity == null)
        {
            return false;
        }

        entity!.Price = price;
        _dbContext.Entry(entity).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
        if (entity == null)
        {
            return false;
        }

        _dbContext.Entry(entity).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();

        return true;
    }
}