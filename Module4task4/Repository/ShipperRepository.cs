using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4task4.Data;
using Module4task4.Models;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class ShipperRepository : IShipperRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ShipperRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> CreateShipperAsync(Shipper shipper)
    {
        var result = await _dbContext.Shippers.AddAsync(new ShippersEntity()
        {
            ShippersId = shipper.ShipperId,
            CompanyName = shipper.CompanyName
        });

        await _dbContext.SaveChangesAsync();
        return result.Entity.ShippersId;
    }

    public async Task<ShippersEntity> UpdateShipperAsync(ShippersEntity shipper)
    {
        if (shipper.ShippersId != default)
        {
            _dbContext.Entry(shipper).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        return shipper;
    }

    public async Task<ShippersEntity?> ReadShipperAsync(int id)
    {
        return await _dbContext.Shippers.FirstOrDefaultAsync(f => f.ShippersId == id);
    }

    public async Task<bool> DeleteShipperAsync(int id)
    {
        ShippersEntity shippers = await _dbContext.Shippers.FirstAsync(c => c.ShippersId == id);
        _dbContext.Shippers.Remove(shippers);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ShippersEntity>> GetOrdersByShipperId(int id)
    {
        return await _dbContext.Shippers.Include(s => s.Orders)
            .Where(e => e.ShippersId == id).ToListAsync();
    }
}