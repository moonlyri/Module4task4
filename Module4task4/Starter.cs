using Module4task4.Models;
using Module4task4.Services.Abstractions;

namespace Module4task4;

public class Starter
{
        private readonly ICreateTableService _createtableService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        public Starter(
            ICustomerService customerService,
            IOrderService orderService,
            IProductService productService,
            ICreateTableService createtableService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
            _createtableService = createtableService;
        }

        public async Task Start()
        {
            var fullName = "Fullname Name";

            var customerId = await _customerService.AddCustomer(fullName);

            await _customerService.GetCustomer(customerId);

            var product1 = await _productService.AddProductAsync("product1", "the best product", 4, "blue");
            var product2 = await _productService.AddProductAsync("product2", "even better product", 5, "black");

            var order1 = await _orderService.AddOrderAsync(customerId, new List<OrderDetails>()
            {
                new OrderDetails()
                {
                    ProductId = product1,
                },

                new OrderDetails()
                {
                    ProductId = product2
                },
            });

            var order2 = await _orderService.AddOrderAsync(customerId, new List<OrderDetails>()
            {
                new OrderDetails()
                {
                    ProductId = product2
                },

                new OrderDetails()
                {
                    ProductId = product1
                },
            });

            var customerOrder = await _orderService.GetOrderByCustomerIdAsync(customerId);

            _createtableService.CreateTable("Table");
        }
    }