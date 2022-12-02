using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Services;

public class SuppliersService : BaseDataService<ApplicationDbContext>, ISuppliersService
{
    private readonly ISuppliersRepository _suppliersRepository;
    private readonly ILogger<SuppliersService> _loggerService;

    public SuppliersService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ISuppliersRepository suppliersRepository,
        ILogger<SuppliersService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _suppliersRepository = suppliersRepository;
        _loggerService = loggerService;
    }

    public async Task<int> SaveSupplierAsync(Supplier supplier)
    {
        await _suppliersRepository.CreateSupplierAsync(supplier);
        _loggerService.LogInformation("Created supplier with Id = {Id}", supplier.SupplierId);
        return supplier.SupplierId;
    }

    public async Task<Supplier> GetSupplierAsync(int id)
    {
        var result = await _suppliersRepository.ReadSupplierAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning("Not found supplier with id: {Id}", id);
            return null!;
        }

        return new Supplier()
        {
            SupplierId = result.SupplierId,
            ContactFName = result.ContactFullname,
            City = result.City,
            CompanyName = result.CompanyName
        };
    }

    public async Task<int> UpdateSupplierAsync(Supplier supplier)
    {
        var result = new SuppliersEntity()
        {
            SupplierId = supplier.SupplierId,
            ContactFullname = supplier.ContactFName,
            CompanyName = supplier.CompanyName,
            City = supplier.City
        };
        await _suppliersRepository.UpdateSupplierAsync(result);
        _loggerService.LogInformation("Modified supplier with Id = {Id}", result.SupplierId);
        return result.SupplierId;
    }

    public async Task<bool> DeleteSupplierAsync(int id)
    {
        await _suppliersRepository.DeleteSupplierAsync(id);
        _loggerService.LogInformation("Deleted supplier with Id = {Id}", id);
        return true;
    }

    public async Task<bool> ClearAllProductsInCertainSupplier(int id)
    {
        await _suppliersRepository.ClearAllProductsInCertainSupplier(id);
        _loggerService.LogInformation("Deleted products in supplier with Id = {Id}", id);
        return true;
    }
}