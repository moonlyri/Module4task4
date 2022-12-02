using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4task4.Data;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderDetailsRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<OrderDetailsEntity?> CreateOrderDetailAsync(int id, int productId, int orderId)
    {
        var orderDetail = new OrderDetailsEntity()
        {
            OrderDetailId = id,
            ProductId = productId,
            OrderId = orderId
        };

        var result = await _dbContext.OrderDetails.AddAsync(orderDetail);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<OrderDetailsEntity> UpdateOrderDetailAsync(OrderDetailsEntity orderDetail)
    {
        if (orderDetail.OrderDetailId != default)
        {
            _dbContext.Entry(orderDetail).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        return orderDetail;
    }

    public async Task<OrderDetailsEntity?> ReadOrderDetailAsync(int id)
    {
        return await _dbContext.OrderDetails.FirstOrDefaultAsync(f => f != null && f.OrderDetailId == id);
    }

    public async Task<bool> DeleteOrderDetailAsync(int? id)
    {
        OrderDetailsEntity? orderDetail = await _dbContext.OrderDetails.FirstAsync(c => c != null && c.OrderDetailId == id);
        _dbContext.OrderDetails.Remove(orderDetail);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}