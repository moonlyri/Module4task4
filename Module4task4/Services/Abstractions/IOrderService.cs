using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface IOrderService
{
    Task<int> AddOrderAsync(string user, List<OrderDetails> order);
    Task<Orders> GetOrderAsync(int id);
    Task<IReadOnlyList<Orders>> GetOrderByCustomerIdAsync(string id);
}