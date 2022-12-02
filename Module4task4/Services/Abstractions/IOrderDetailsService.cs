using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface IOrderDetailsService
{
    Task<OrderDetails> SaveOrderDetailAsync(int id, int productId, int orderId);
    Task<int?> UpdateOrderDetailAsync(OrderDetails orderDetail);
    Task<OrderDetails> GetOrderDetailAsync(int id);
    Task<bool> DeleteOrderDetailAsync(int? id);
}