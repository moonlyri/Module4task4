using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<CategoryEntity?> ReadCategoryAsync(int id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(f => f.CategoryId == id);
    }

    public async Task<int> CreateCategoryAsync(Category category)
    {
        var result = await _dbContext.Categories.AddAsync(new CategoryEntity()
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName
        });

        await _dbContext.SaveChangesAsync();
        return result.Entity.CategoryId;
    }

    public async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category)
    {
        if (category.CategoryId != default)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        return category;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        CategoryEntity category = await _dbContext.Categories.FirstAsync(c => c.CategoryId == id);
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}