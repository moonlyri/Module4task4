using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Services;

public class PaymentService : BaseDataService<ApplicationDbContext>, IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILogger<PaymentService> _loggerService;

    public PaymentService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IPaymentRepository paymentRepository,
        ILogger<PaymentService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _paymentRepository = paymentRepository;
        _loggerService = loggerService;
    }

    public async Task<int> SavePaymentAsync(Payment payment)
    {
        await _paymentRepository.CreatePaymentAsync(payment);
        _loggerService.LogInformation("Created payment with Id = {PaymentPaymentId}", payment.PaymentId);
        return payment.PaymentId;
    }

    public async Task<Payment> GetPaymentAsync(int id)
    {
        var result = await _paymentRepository.ReadPaymentAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning("Not founded payments with ia {Id}", id);
            return null!;
        }

        return new Payment()
        {
            PaymentId = result.PaymentId,
            PaymentType = result.PaymentType
        };
    }

    public async Task<int> UpdatePaymentAsync(Payment payment)
    {
        var result = new PaymentEntity()
        {
            PaymentId = payment.PaymentId,
            PaymentType = payment.PaymentType
        };
        await _paymentRepository.UpdatePaymentAsync(result);
        _loggerService.LogInformation("Modified payment with Id = {ResultPaymentId}", result.PaymentId);
        return result.PaymentId;
    }

    public async Task<bool> DeletePaymentAsync(int id)
    {
        await _paymentRepository.DeletePaymentAsync(id);
        _loggerService.LogInformation("Deleted payment with Id = {Id}", id);
        return true;
    }

    public async Task<IReadOnlyList<Payment>> GetOrdersByPaymentType(string paymentType)
    {
        var result = await _paymentRepository.GetOrdersByPaymentType(paymentType);

        return result.Select(r =>
        {
            Debug.Assert(r.Orders != null, "r.Orders != null");
            return new Payment()
            {
                PaymentId = r.PaymentId,
                PaymentType = r.PaymentType,
                Orders = r.Orders.Select(e => new Orders()
                {
                    OrderId = e.OrderId,
                    CustomerId = e.CustomerId,
                    PaymentId = e.PaymentId,
                    ShippersId = e.ShippersId,
                })
            };
        }).ToList();
    }
}