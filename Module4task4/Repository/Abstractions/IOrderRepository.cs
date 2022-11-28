using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Module4task4.Models;

namespace Module4task4.Repository.Abstractions;

public interface IOrderRepository
{
    Task<int> AddOrderAsync(string customer, List<OrderDetails> order);
    Task<OrdersEntity?> GetOrderAsync(int id);
    Task<IEnumerable<OrdersEntity>?> GetOrderByUserIdAsync(string id);
}