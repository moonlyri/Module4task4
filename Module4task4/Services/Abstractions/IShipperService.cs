using System.Collections.Generic;
using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface IShipperService
{
    Task<int> SaveShipperAsync(Shipper shipper);
    Task<int> UpdateShipperAsync(Shipper shipper);
    Task<Shipper> GetShipperAsync(int id);
    Task<bool> DeleteShipperAsync(int id);
    Task<IReadOnlyList<Shipper>> GetOrdersByShipperId(int id);
}