using System.Collections.Generic;
using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Repository.Abstractions;

public interface IOrderRepository
{
    Task<int> AddOrderAsync(int customerId, List<OrderDetails> items);

    Task<OrdersEntity?> GetOrderAsync(int id);

    Task<IEnumerable<OrdersEntity>?> GetOrderByCustomerIdAsync(int id);
}