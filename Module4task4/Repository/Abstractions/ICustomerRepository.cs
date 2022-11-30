using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Repository.Abstractions;

public interface ICustomerRepository
{
    Task<int> AddCustomerAsync(string fullname);
    Task<Customer> GetCustomerAsync(int id);
}