using System.Collections.Generic;
using System.Threading.Tasks;
using Module4task4.Models;
using Module4task4.Services.Abstractions;

namespace Module4task4;

public class Starter
{
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public Starter(
            ICustomerService customerService,
            IOrderService orderService,
            IProductService productService)
        {
            this.customerService = customerService;
            this.orderService = orderService;
            this.productService = productService;
        }

        public async Task Start()
        {
            var fullName = "Fullname Name";

            var customer = await this.customerService.AddCustomer(fullName);

            await this.customerService.GetCustomer(customer);

            var product1 = await this.productService.AddProductAsync("product1", "the best product", 4, "blue");
            var product2 = await this.productService.AddProductAsync("product2", "even better product", 5, "black");

            var order1 = await this.orderService.AddOrderAsync(123, 345, 234);
            {
                new OrderDetails()
                {
                    ProductId = product1,
                };

                new OrderDetails()
                {
                    ProductId = product2,
                };
            }

            var order2 = await this.orderService.AddOrderAsync(123, 234, 345);
            {
                new OrderDetails()
                {
                    ProductId = product2,
                };

                new OrderDetails()
                {
                    ProductId = product1,
                };
            }

            var customerOrder = await this.orderService.GetOrderAsync(123);

        }
    }