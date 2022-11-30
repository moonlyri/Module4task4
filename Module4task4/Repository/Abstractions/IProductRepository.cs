using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Module4task4.Models;

namespace Module4task4.Repository.Abstractions;

public interface IProductRepository
{
    Task<int> AddProductAsync(string name, string description, int size, string color);
    Task<Product> GetProductAsync(int id);
}