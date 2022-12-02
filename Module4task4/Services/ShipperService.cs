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

public class ShipperService : BaseDataService<ApplicationDbContext>, IShipperService
{
    private readonly IShipperRepository _shipperRepository;
    private readonly ILogger<ShipperService> _loggerService;

    public ShipperService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IShipperRepository shipperRepository,
        ILogger<ShipperService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _shipperRepository = shipperRepository;
        _loggerService = loggerService;
    }

    public async Task<int> SaveShipperAsync(Shipper shipper)
    {
        await _shipperRepository.CreateShipperAsync(shipper);
        _loggerService.LogInformation("Created shipper with Id = {Id}", shipper.ShipperId);
        return shipper.ShipperId;
    }

    public async Task<Shipper> GetShipperAsync(int id)
    {
        var result = await _shipperRepository.ReadShipperAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning("Not found shipper with id: {Id}", id);
            return null!;
        }

        return new Shipper()
        {
            ShipperId = result.ShippersId,
            CompanyName = result.CompanyName
        };
    }

    public async Task<int> UpdateShipperAsync(Shipper shipper)
    {
        var result = new ShippersEntity()
        {
            ShippersId = shipper.ShipperId,
            CompanyName = shipper.CompanyName
        };
        await _shipperRepository.UpdateShipperAsync(result);
        _loggerService.LogInformation("Modified shipper with Id = {ShippersId}", result.ShippersId);
        return result.ShippersId;
    }

    public async Task<bool> DeleteShipperAsync(int id)
    {
        await _shipperRepository.DeleteShipperAsync(id);
        _loggerService.LogInformation("Deleted shipper with Id = {Id}", id);
        return true;
    }

    public async Task<IReadOnlyList<Shipper>> GetOrdersByShipperId(int id)
    {
        var result = await _shipperRepository.GetOrdersByShipperId(id);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (result == null)
        {
            _loggerService.LogWarning("Not found orders by shipper id = {Id} ", id);
            return null!;
        }

        return result.Select(r =>
        {
            Debug.Assert(r.Orders != null, "r.Orders != null");
            return new Shipper()
            {
                ShipperId = r.ShippersId,
                CompanyName = r.CompanyName,
                Orders = r.Orders.Select(e => new Orders()
                    {
                        OrderId = e.OrderId,
                        CustomerId = e.CustomerId,
                        PaymentId = e.PaymentId,
                        ShippersId = e.ShippersId
                    })
            };
        }).ToList();
    }
}