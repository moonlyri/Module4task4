using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface ISuppliersService
{
    Task<int> SaveSupplierAsync(Supplier supplier);
    Task<int> UpdateSupplierAsync(Supplier supplier);
    Task<Supplier> GetSupplierAsync(int id);
    Task<bool> DeleteSupplierAsync(int id);
    Task<bool> ClearAllProductsInCertainSupplier(int id);
}