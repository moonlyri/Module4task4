using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PaymentRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> CreatePaymentAsync(Payment payment)
    {
        var result = await _dbContext.Payments.AddAsync(new PaymentEntity()
        {
            PaymentId = payment.PaymentId,
            PaymentType = payment.PaymentType
        });

        await _dbContext.SaveChangesAsync();
        return result.Entity.PaymentId;
    }

    public async Task<PaymentEntity> UpdatePaymentAsync(PaymentEntity payment)
    {
        if (payment.PaymentId != default)
        {
            _dbContext.Entry(payment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        return payment;
    }

    public async Task<PaymentEntity?> ReadPaymentAsync(int id)
    {
        return await _dbContext.Payments.FirstOrDefaultAsync(f => f.PaymentId == id);
    }

    public async Task<bool> DeletePaymentAsync(int id)
    {
        PaymentEntity payment = await _dbContext.Payments.FirstAsync(c => c.PaymentId == id);
        _dbContext.Payments.Remove(payment);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<PaymentEntity>> GetOrdersByPaymentType(string paymentType)
    {
        return await _dbContext.Payments.Where(s => s.PaymentType == paymentType)
            .Include(e => e.Orders).ToListAsync();
    }
}