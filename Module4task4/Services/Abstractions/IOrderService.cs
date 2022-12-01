using System.Collections.Generic;
using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface IOrderService
{
    Task<int> AddOrderAsync(int customer, List<OrderDetails> items);
    Task<Orders> GetOrderAsync(int id);
    Task<IReadOnlyList<Orders>> GetOrderByCustomerIdAsync(int id);
}