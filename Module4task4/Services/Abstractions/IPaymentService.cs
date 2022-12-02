using System.Collections.Generic;
using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Services.Abstractions;

public interface IPaymentService
{
    Task<int> SavePaymentAsync(Payment payment);
    Task<int> UpdatePaymentAsync(Payment payment);
    Task<Payment> GetPaymentAsync(int id);
    Task<bool> DeletePaymentAsync(int id);
    Task<IReadOnlyList<Payment>> GetOrdersByPaymentType(string paymentType);
}