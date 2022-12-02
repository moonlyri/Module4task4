using System.Threading.Tasks;

namespace Module4task4.Repository.Abstractions;

public interface IOrderDetailsRepository
{
    Task<OrderDetailsEntity?> CreateOrderDetailAsync(int id, int productId, int orderId);
    Task<OrderDetailsEntity> UpdateOrderDetailAsync(OrderDetailsEntity orderDetail);
    Task<OrderDetailsEntity?> ReadOrderDetailAsync(int id);
    Task<bool> DeleteOrderDetailAsync(int? id);
}