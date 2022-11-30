using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface ICustomerService
{
    Task<int> AddCustomer(string fullname);
    Task<Customer> GetCustomer(int id);
    
}