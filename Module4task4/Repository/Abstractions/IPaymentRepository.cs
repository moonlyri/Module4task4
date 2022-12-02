using System.Collections.Generic;
using System.Threading.Tasks;
using Module4task4.Models;

namespace Module4task4.Repository.Abstractions;

public interface IPaymentRepository
{
    Task<int> CreatePaymentAsync(Payment payment);
    Task<PaymentEntity> UpdatePaymentAsync(PaymentEntity payment);
    Task<PaymentEntity?> ReadPaymentAsync(int id);
    Task<bool> DeletePaymentAsync(int id);
    Task<IEnumerable<PaymentEntity>> GetOrdersByPaymentType(string paymentType);
}