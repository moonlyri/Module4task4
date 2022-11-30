using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class CustomersRepository : BaseRepository, ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomersRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddCustomerAsync(string fullname)
    {
        var customer = new CustomersEntity()
        {
            FullName = fullname,
        };

        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();

        return customer.Id;
    }
    

    public async Task<Customer?> GetCustomerAsync(int id)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<Customer>(customer);
    }
}