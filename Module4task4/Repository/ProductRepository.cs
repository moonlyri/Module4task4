using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class ProductRepository : BaseRepository, IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddProductAsync(string name, string description, int size, string color)
    {
        var product = new ProductsEntity()
        {
            ProductName = name,
            ProductDescription = description,
            Size = size,
            Color = color,
        };

        var result = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
        return Mapper.Map<Product>(product);
    }
}