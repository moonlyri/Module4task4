#nullable enable
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4task4.Data;
using Module4task4.Repository.Abstractions;

namespace Module4task4.Repository;

public class CustomersRepository : BaseRepository, ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomersRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddCustomerAsync(string fullname)
    {
        var customer = new CustomersEntity()
        {
            Id = Convert.ToInt32(Guid.NewGuid().ToString()),
            FullName = fullname
        };

        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();

        return customer.Id;
    }

    public async Task<CustomersEntity?> GetCustomerAsync(int id)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(f => f.Id == id);
    }
}