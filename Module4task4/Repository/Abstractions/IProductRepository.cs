using System.Threading.Tasks;

namespace Module4task4.Repository.Abstractions;

public interface IProductRepository
{
    Task<int> AddProductAsync(string name, decimal price);
    Task<ProductsEntity?> GetProductAsync(int id);
    Task<bool> UpdatePrice(int id, decimal price);
    Task<bool> Delete(int id);
}