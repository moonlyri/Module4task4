using System.Threading.Tasks;

namespace Module4task4.Repository.Abstractions;

public interface ICustomerRepository
{
    Task<int> AddCustomerAsync(string fullname);

    Task<CustomersEntity?> GetCustomerAsync(int id);
}