using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Services;

public class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<CategoryService> _loggerService;

    public CategoryService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICategoryRepository categoryRepository,
        ILogger<CategoryService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _categoryRepository = categoryRepository;
        _loggerService = loggerService;
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        var result = await _categoryRepository.ReadCategoryAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning("Not found category with Id {Id}", id);
            return null!;
        }

        return new Category()
        {
            CategoryId = result.CategoryId,
            CategoryName = result.CategoryName
        };
    }

    public async Task<int> UpdateCategoryAsync(Category category)
    {
        var result = new CategoryEntity()
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName
        };
        await _categoryRepository.UpdateCategoryAsync(result);
        _loggerService.LogInformation("Modified category with Id = {Id}", result.CategoryId);
        return result.CategoryId;
    }

    public async Task<int> SaveCategoryAsync(Category category)
    {
        await _categoryRepository.CreateCategoryAsync(category);
        _loggerService.LogInformation("Created category with Id = {Id}", category.CategoryId);
        return category.CategoryId;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        await _categoryRepository.DeleteCategoryAsync(id);
        _loggerService.LogInformation("Deleted category with Id = {Id}", id);
        return true;
    }
}