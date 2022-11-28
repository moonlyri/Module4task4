using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface ICustomerService
{
    Task<string> AddCustomer(string fullname);
    Task<Customer> GetCustomer(string id);
    
}