using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Module4task4.Repository.Abstractions;

public interface IProductRepository
{
    Task<int> AddProductAsync(string name, string description, int size, string color);
    Task<ProductsEntity?> GetProductAsync(int id);
}