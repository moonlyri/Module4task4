using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Module4task4.Models;

namespace Module4task4.Repository.Abstractions;

public interface IProductRepository
{
    Task<int> AddProductAsync(string name, decimal price);
    Task<ProductsEntity?> GetProductAsync(int id);
    Task<bool> UpdatePrice(int id, decimal price);
    Task<bool> Delete(int id);
}