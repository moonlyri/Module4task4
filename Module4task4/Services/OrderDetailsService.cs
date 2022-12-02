using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Services;

public class OrderDetailsServices : BaseDataService<ApplicationDbContext>, IOrderDetailsService
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    private readonly ILogger<OrderDetailsServices> _loggerService;

    public OrderDetailsServices(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IOrderDetailsRepository orderDetailsRepository,
        ILogger<OrderDetailsServices> loggerService)
        : base(dbContextWrapper, logger)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _loggerService = loggerService;
    }

    public async Task<OrderDetails> GetOrderDetailAsync(int id)
    {
        var result = await _orderDetailsRepository.ReadOrderDetailAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning("Not founded order details {Id}", id);
            return null!;
        }

        return new OrderDetails()
        {
            OrderDetailId = result.OrderDetailId,
            OrderId = result.OrderId,
            ProductId = result.ProductId,
            Price = result.Price
        };
    }

    public async Task<OrderDetails> SaveOrderDetailAsync(int id, int productId, int orderId)
    {
        var result = await _orderDetailsRepository.CreateOrderDetailAsync(id, productId, orderId);
        Debug.Assert(result != null, nameof(result) + " != null");
        _loggerService.LogInformation("Created order detail with Id = {OrderDetailId}", result.OrderDetailId);
        return new OrderDetails()
        {
            OrderDetailId = result.OrderDetailId,
            OrderId = result.OrderId,
            ProductId = result.ProductId,
            Price = result.Price
        };
    }

    public async Task<int?> UpdateOrderDetailAsync(OrderDetails orderDetail)
    {
        var result = new OrderDetailsEntity()
        {
            OrderDetailId = orderDetail.OrderDetailId,
            OrderId = orderDetail.OrderId,
            Count = orderDetail.Count,
            ProductId = orderDetail.ProductId
        };
        await _orderDetailsRepository.UpdateOrderDetailAsync(result);
        _loggerService.LogInformation("Update order detail with Id = {OrderDetailId}", result.OrderDetailId);
        return result.OrderDetailId;
    }

    public async Task<bool> DeleteOrderDetailAsync(int? id)
    {
        await _orderDetailsRepository.DeleteOrderDetailAsync(id);
        _loggerService.LogInformation("Delete order detail with Id = {Id}", id);
        return true;
    }
}