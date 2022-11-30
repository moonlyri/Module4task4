using AutoMapper;
using Module4task4.Models;

namespace Module4task4.Map;

public class ModelsToEntity : Profile
{
    public ModelsToEntity()
    {
        CreateMap<Customer, CustomersEntity>();
        CreateMap<Orders, OrdersEntity>();
        CreateMap<OrderDetails, OrderDetailsEntity>();
        CreateMap<Product, ProductsEntity>();
    }
}