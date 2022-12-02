// <copyright file="OrderRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;

namespace Module4task4.Repository;

public class OrderRepository : BaseRepository, IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<int> AddOrderAsync(int customerId, List<OrderDetails> items)
    {
        var result = await _dbContext.Orders.AddAsync(new OrdersEntity()
        {
            CustomerId = customerId
        });

        await _dbContext.OrderDetails.AddRangeAsync(items.Select(s => new OrderDetailsEntity()
        {
            OrderId = result.Entity.CustomerId,
            ProductId = s.ProductId
        }));

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public Task<int> AddOrderAsync(int customer, int paymentId, int shipperId)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<OrdersEntity?> GetOrderAsync(int id)
    {
        return await _dbContext.Orders.Include(i => i.OrderDetails).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<OrdersEntity>?> GetOrderByCustomerIdAsync(int id)
    {
        return await _dbContext.Orders.Include(i => i.OrderDetails).Where(f => f.CustomerId == id).ToListAsync();
    }
}