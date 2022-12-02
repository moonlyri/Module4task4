using System.Collections.Generic;
using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Repository.Abstractions;

public interface IShipperRepository
{
    Task<int> CreateShipperAsync(Shipper shipper);
    Task<ShippersEntity> UpdateShipperAsync(ShippersEntity shipper);
    Task<ShippersEntity?> ReadShipperAsync(int id);
    Task<bool> DeleteShipperAsync(int id);
    Task<IEnumerable<ShippersEntity>> GetOrdersByShipperId(int id);
}