using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Services;

public class ProductService : BaseDataService<ApplicationDbContext>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _loggerService;

    public ProductService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IProductRepository productRepository,
        ILogger<ProductService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _productRepository = productRepository;
        _loggerService = loggerService;
    }

    public async Task<int> AddProductAsync(string name, decimal price)
    {
        var id = await _productRepository.AddProductAsync(name, price);
        _loggerService.LogInformation("Created product with Id = {Id}", id);
        return id;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        var result = await _productRepository.GetProductAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning("Product nor found: {Id}", id);
            return null!;
        }

        return new Product()
        {
            Id = result.Id,
            ProductName = result.ProductName,
            Price = result.Price,
            ProductDescription = result.ProductDescription
        };
    }

    public async Task<bool> UpdatePrice(int id, decimal price)
    {
        var result = await _productRepository.UpdatePrice(id, price);

        if (!result)
        {
            _loggerService.LogWarning("Product not found: {Id} for update", id);
            return false;
        }

        _loggerService.LogInformation("Product with Id = {Id} was updated", id);
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _productRepository.Delete(id);

        if (!result)
        {
            _loggerService.LogWarning("Product not found: {Id} for delete", id);
            return false;
        }

        _loggerService.LogInformation("Product with Id = {Id} was deleted", id);
        return true;
    }
}