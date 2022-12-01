using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface IProductService
{
    Task<int> AddProductAsync(string name, decimal price);
    Task<Product> GetProductAsync(int id);
    Task<bool> UpdatePrice(int id, decimal price);
    Task<bool> Delete(int id);
}