using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class OrderRepository : BaseRepository, IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
        dbContext = _dbContext;
    }

    public async Task<int> AddOrderAsync(int customer, int paymentId, int shipperId)
    {
        var order = new OrdersEntity()
        {
            CustomerId = customer, PaymentId = paymentId, ShipperId = shipperId,
        };
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        return order.Id;
    }

    public async Task<Orders> GetOrderAsync(int id)
    {
        var order = await _dbContext.Orders.Include(i => i.OrderDetails)
            .FirstOrDefaultAsync(f => f.Id == id);
        return Mapper.Map<Orders>(order);
    }

    public async Task<Orders> GetOrderByCustomerIdAsync(int id)
    {
        var order = await _dbContext.Orders
            .Include(el => el.OrderDetails)
            .ThenInclude(el => el.Products)
            .Include(el => el.Shippers)
            .Include(el => el.Payment)
            .Include(el => el.Customers)
            .FirstOrDefaultAsync(el => el.Id == id);

        return Mapper.Map<Orders>(order);
    }
}