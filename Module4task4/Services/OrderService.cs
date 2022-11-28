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

    public async Task<int> AddOrderAsync(string user, List<OrderDetails> items)
    {
        var id = await _orderRepository.AddOrderAsync(user, items);
        _loggerService.LogInformation($"Created order with Id = {id}");
        return id;
    }

    public async Task<Orders> GetOrderAsync(int id)
    {
        var result = await _orderRepository.GetOrderAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded order with Id = {id}");
            return null!;
        }

        return new Orders()
        {
            CustomerId = result.Id,
            OrderDetails = result.OrderDetails.Select(s => new OrderDetailsEntity()
            {
                ProductId = s.ProductId,
                Products = new Product()
                {
                    Id = s.Products!.Id,
                    ProductName = s.Products.ProductName,
                    Size = s.Products.Size,
                    ProductDescription = s.Products.ProductDescription,
                    Color = s.Products.Color
                }
            })
        };
    }


    public async Task<IReadOnlyList<Orders>> GetOrderByCustomerIdAsync(string id)
    {
        var result = await _orderRepository.GetOrderByUserIdAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded order fot current user Id = {id}");
            return null!;
        }

        return result.Select(r => new Orders()
        {
            CustomerId = r.Id,
            OrderDetails = r.OrderDetails.Select(s => new OrderDetailsEntity()
            {
                ProductId = s.ProductId,
                Products = new Product()
                {
                    Id = s.ProductId,
                    ProductName = s.Products.ProductName,
                    Size = s.Products.Size,
                    ProductDescription = s.Products.ProductDescription,
                    Color = s.Products.Color
                }
            })
        }).ToList();
    }
}