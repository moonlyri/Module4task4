using Microsoft.EntityFrameworkCore;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class CustomersRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomersRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<string> AddCustomerAsync(string fullname)
    {
        var customer = new CustomersEntity()
        {
            Id = Guid.NewGuid().ToString(),
            FullName = fullname
        };

        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();

        return customer.Id.ToString();
    }
    

    public async Task<CustomersEntity?> GetCustomerAsync(string id)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(f => f.Id == id);
    }
}