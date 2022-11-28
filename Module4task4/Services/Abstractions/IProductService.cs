using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface IProductService
{
    Task<int> AddProductAsync(string name, string description, int size, string color);
    Task<Product> GetProductAsync(int id);
}