using Microsoft.Extensions.Logging;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;

namespace Module4task4.Services.Abstractions;

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

    public async Task<int> AddProductAsync(string name, string description, int size, string color)
    {
        var id = await _productRepository.AddProductAsync(name, description, size, color);
        _loggerService.LogInformation($"Created product with Id = {id}");
        return id;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        var result = await _productRepository.GetProductAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Product not found: {id}");
            return null!;
        }

        return new Product()
        {
            Id = result.Id,
            ProductName = result.ProductName,
            Size = result.Size,
            Color = result.Color,
            ProductDescription = result.ProductDescription
        };
    }
}