using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class SuppliersRepository : ISuppliersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SuppliersRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> CreateSupplierAsync(Supplier supplier)
    {
        var result = await _dbContext.Suppliers.AddAsync(new SuppliersEntity()
        {
            SupplierId = supplier.SupplierId,
            ContactFullname = supplier.ContactFName,
            CompanyName = supplier.CompanyName,
            City = supplier.City
        });

        await _dbContext.SaveChangesAsync();
        return result.Entity.SupplierId;
    }

    public async Task<SuppliersEntity?> UpdateSupplierAsync(SuppliersEntity supplier)
    {
        if (supplier.SupplierId != default)
        {
            _dbContext.Entry(supplier).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        return supplier;
    }

    public async Task<SuppliersEntity?> ReadSupplierAsync(int id)
    {
        return await _dbContext.Suppliers.FirstOrDefaultAsync(f => f.SupplierId == id);
    }

    public async Task<bool> DeleteSupplierAsync(int id)
    {
        SuppliersEntity suppliers = await _dbContext.Suppliers.FirstAsync(c => c.SupplierId == id);
        _dbContext.Suppliers.Remove(suppliers);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ClearAllProductsInCertainSupplier(int id)
    {
        await _dbContext.Suppliers.Where(w => w.SupplierId == id)
            .Select(p => p.Products).ForEachAsync(e => e?.Clear());
        return true;
    }
}