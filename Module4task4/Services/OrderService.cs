using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Services;

public class OrderService : BaseDataService<ApplicationDbContext>, IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<CustomerService> _loggerService;

    public OrderService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IOrderRepository orderRepository,
        ILogger<CustomerService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _orderRepository = orderRepository;
        _loggerService = loggerService;
    }

    public async Task<int> AddOrderAsync(int customerid, int paymentId, int shipperId)
    {
        var id = await _orderRepository.AddOrderAsync(customerid, paymentId, shipperId);
        _loggerService.LogInformation("Created order with Id = {Id}", id);
        return id;
    }

    public async Task<Orders> GetOrderAsync(int id)
    {
        var item = await _orderRepository.GetOrderByCustomerIdAsync(id);
        return item;
    }
}