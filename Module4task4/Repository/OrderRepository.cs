using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> AddOrderAsync(string customer, List<OrderDetails> order)
    {
        var result = await _dbContext.Orders.AddAsync(new OrdersEntity()
        {
            CustomerId = customer
        });

        await _dbContext.OrderDetails.AddRangeAsync(order.Select(s => new OrderDetailsEntity()
        {
            OrderId = result.Entity.Id,
            ProductId = s.ProductId
        }));

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<OrdersEntity?> GetOrderAsync(int id)
    {
        return await _dbContext.Orders.Include(i => i.OrderDetails)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<OrdersEntity>?> GetOrderByUserIdAsync(string id)
    {
        return await _dbContext.Orders.Include(i => i.OrderDetails)
            .Where(f => f.CustomerId == id).ToListAsync();
    }
}