namespace Module4task4.Repository.Abstractions;

public interface ICustomerRepository
{
    Task<string> AddCustomerAsync(string fullname);
    Task<CustomersEntity?> GetCustomerAsync(string id);
}