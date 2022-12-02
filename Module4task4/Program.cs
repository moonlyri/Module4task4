// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Module4task4;
using Module4task4.Config;
using Module4task4.Data;
using Module4task4.Repository;
using Module4task4.Repository.Abstractions;
using Module4task4.Services;
using Module4task4.Services.Abstractions;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts
        => opts.UseNpgsql(connectionString));
    serviceCollection.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

    serviceCollection
        .AddDbContextFactory<ApplicationDbContext>(opts => opts.UseNpgsql(connectionString))
        .AddTransient<ICustomerService, CustomerService>()
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<ICustomerRepository, CustomersRepository>()
        .AddTransient<IOrderRepository, OrderRepository>()
        .AddTransient<IProductRepository, ProductRepository>()
        .AddTransient<ICategoryRepository, CategoryRepository>()
        .AddTransient<IOrderDetailsRepository, OrderDetailsRepository>()
        .AddTransient<IPaymentRepository, PaymentRepository>()
        .AddTransient<IShipperRepository, ShipperRepository>()
        .AddTransient<ISuppliersRepository, SuppliersRepository>()
        .AddTransient<IOrderService, OrderService>()
        .AddTransient<IProductService, ProductService>()
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<ICustomerService, CustomerService>()
        .AddTransient<IOrderDetailsService, OrderDetailsServices>()
        .AddTransient<IPaymentService, PaymentService>()
        .AddTransient<IShipperService, ShipperService>()
        .AddTransient<ISuppliersService, SuppliersService>()
        .AddTransient<Starter>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<Starter>();
await app!.Start();
