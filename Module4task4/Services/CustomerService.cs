using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Services;

public class CustomerService : BaseDataService<ApplicationDbContext>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _loggerService;

        public CustomerService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICustomerRepository customerRepository,
            ILogger<CustomerService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _customerRepository = customerRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddCustomer(string fullname)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _customerRepository.AddCustomerAsync(fullname);
                _loggerService.LogInformation("Added customer with id: {Id}", id);
                return id;
            });
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);

            if (customer == null)
            {
                _loggerService.LogWarning("Customer not found: {Id}", id);
                return null!;
            }

            return new Customer()
            {
                Fullname = customer.FullName
            };
        }
    }