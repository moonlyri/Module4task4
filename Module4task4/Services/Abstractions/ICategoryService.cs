using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface ICategoryService
{
    Task<int> SaveCategoryAsync(Category category);
    Task<int> UpdateCategoryAsync(Category category);
    Task<Category> GetCategoryAsync(int id);
    Task<bool> DeleteCategoryAsync(int id);
}