using System.Collections.Generic;
using System.Threading.Tasks;
using Module4task4.Models;
using Module4task4.Services.Abstractions;

namespace Module4task4;

public class Starter
{
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        public Starter(
            ICustomerService customerService,
            IOrderService orderService,
            IProductService productService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
        }


        public async Task Start()
        {
            var fullname = "Boris Jonsonuk";

            var customerId = await _customerService.AddCustomer(fullname);

            await _customerService.GetCustomer(customerId);

            var product1 = await _productService.AddProductAsync("product1", 4);
            var product2 = await _productService.AddProductAsync("product2", 7);

            var order1 = await _orderService.AddOrderAsync(customerId, new List<OrderDetails>()
            {
                new OrderDetails()
                {
                    Count = 2,
                    ProductId = product1
                },

                new OrderDetails()
                {
                    Count = 6,
                    ProductId = product2,
                },
            });

            var order2 = await _orderService.AddOrderAsync(customerId, new List<OrderDetails>()
            {
                new OrderDetails()
                {
                    Count = 1,
                    ProductId = product1
                },

                new OrderDetails()
                {
                    Count = 9,
                    ProductId = product2
                },
            });

            var userOrder = await _orderService.GetOrderByCustomerIdAsync(customerId);

            await _productService.UpdatePrice(product1, 355);
            await _productService.Delete(product2);
        }
    }