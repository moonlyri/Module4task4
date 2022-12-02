using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Repository.Abstractions;

public interface ICategoryRepository
{
    Task<int> CreateCategoryAsync(Category category);
    Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category);
    Task<CategoryEntity?> ReadCategoryAsync(int id);
    Task<bool> DeleteCategoryAsync(int id);
}