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

    public async Task<int> AddOrderAsync(int customer, List<OrderDetails> items)
    {
        var id = await _orderRepository.AddOrderAsync(customer, items);
        _loggerService.LogInformation("Created order with Id = {Id}", id);
        return id;
    }

    public async Task<Orders> GetOrderAsync(int id)
    {
        var result = await _orderRepository.GetOrderAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning("Order not found: {Id}", id);
            return null!;
        }

        return new Orders()
        {
            Id = result.Id,
            OrderDetails = result.OrderDetails.Select(s => new OrderDetails()
            {
                ProductId = s.ProductId,
                Products = new Product()
                {
                    Id = s.Products!.Id,
                    ProductName = s.Products.ProductName,
                    Price = s.Products.Price,
                    Count = s.Count
                }
            })
        };
    }

    public async Task<IReadOnlyList<Orders>> GetOrderByCustomerIdAsync(int id)
    {
        var result = await _orderRepository.GetOrderByCustomerIdAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning("Customer nor found: {Id}", id);
            return null!;
        }

        return result.Select(r => new Orders()
        {
            Id = r.Id,
            OrderDetails = r.OrderDetails.Select(s => new OrderDetails()
            {
                Price = s.Price,
                Count = s.Count,
                Products = new Product()
                {
                    Id = s.Products!.Id,
                    ProductName = s.Products.ProductName,
                    Price = s.Products.Price
                }
            })
        }).ToList();
    }
}