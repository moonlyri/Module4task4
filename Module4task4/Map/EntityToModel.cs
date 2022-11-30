using AutoMapper;
using Module4task4.Models;

namespace Module4task4.Map;

public class EntityToModel : Profile
{
    public EntityToModel()
    {
        CreateMap<CustomersEntity, Customer>();
        CreateMap<OrdersEntity, Orders>();
        CreateMap<OrderDetailsEntity, OrderDetails>();
        CreateMap<ProductsEntity, Product>();
    }
}