using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Repository.Abstractions;

public interface ISuppliersRepository
{
    Task<int> CreateSupplierAsync(Supplier payment);
    Task<SuppliersEntity?> UpdateSupplierAsync(SuppliersEntity payment);
    Task<SuppliersEntity?> ReadSupplierAsync(int id);
    Task<bool> DeleteSupplierAsync(int id);
    Task<bool> ClearAllProductsInCertainSupplier(int id);
}