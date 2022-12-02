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
        private readonly ICategoryService _categoryService;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IPaymentService _paymentService;
        private readonly IShipperService _shipperService;
        private readonly ISuppliersService _suppliersService;

        public Starter(
            ICustomerService customerService,
            IOrderService orderService,
            IProductService productService,
            ICategoryService categoryService,
            IOrderDetailsService orderDetailsService,
            IPaymentService paymentService,
            IShipperService shipperService,
            ISuppliersService suppliersService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
            _categoryService = categoryService;
            _orderDetailsService = orderDetailsService;
            _paymentService = paymentService;
            _shipperService = shipperService;
            _suppliersService = suppliersService;
        }

        public async Task Start()
        {
            var fullname = "Boris Jhonsonuk";

            var customerId = await _customerService.AddCustomer(fullname);

            await _customerService.GetCustomer(customerId);

            var product1 = await _productService.AddProductAsync("product1", 4);
            var product2 = await _productService.AddProductAsync("product2", 7);

            var order1 = await _orderService.AddOrderAsync(customerId, new List<OrderDetails>()
            {
                new OrderDetails()
                {
                    Count = 2,
                    ProductId = product1,
                    OrderId = 234,
                    OrderDetailId = 453
                },

                new OrderDetails()
                {
                    Count = 6,
                    ProductId = product2,
                    OrderId = 342
                },
            });

            var order2 = await _orderService.AddOrderAsync(customerId, new List<OrderDetails>()
            {
                new OrderDetails()
                {
                    Count = 1,
                    ProductId = product1,
                    OrderId = 123
                },

                new OrderDetails()
                {
                    Count = 9,
                    ProductId = product2,
                    OrderDetailId = 342,
                    OrderId = 342
                },
            });

            var userOrder = await _orderService.GetOrderByCustomerIdAsync(customerId);
            var category = new Category()
            {
                CategoryId = 1,
                CategoryName = "category"
            };
            var payment = new Payment()
            {
                PaymentId = 1,
                PaymentType = "cash"
            };
            var shipper = new Shipper()
            {
                ShipperId = 1,
                CompanyName = "Company"
            };
            var supplier = new Supplier()
            {
                SupplierId = 1,
                ContactFName = "Volodya Ze",
                CompanyName = "Ze",
                City = "Kyiv"
            };
            var orderDetailsId = new OrderDetails()
            {
                OrderId = 34,
                OrderDetailId = 123,
                Count = 4,
                Price = 1,
                ProductId = 67
            };

            await _categoryService.SaveCategoryAsync(category);
            await _categoryService.GetCategoryAsync(category.CategoryId);
            await _categoryService.UpdateCategoryAsync(category);
            await _shipperService.SaveShipperAsync(shipper);
            await _paymentService.SavePaymentAsync(payment);
            await _suppliersService.SaveSupplierAsync(supplier);
            var orderDetails = await _orderDetailsService.SaveOrderDetailAsync(1, 234, 453);
            var getorder = await _orderService.GetOrderAsync(432);
            var getCustomer = await _customerService.GetCustomer(123);
            var getOrdersByCustomerIdAsync = await _orderService.GetOrderByCustomerIdAsync(123);
            var getOrdersByPaymentType = await _paymentService.GetOrdersByPaymentType(
                payment.PaymentType);
            var getProduct = await _productService.GetProductAsync(category.CategoryId);
            var getOrdersByShipperId = await _shipperService.GetOrdersByShipperId(
                supplier.SupplierId);
            var clearAllProductsInCertainSupplier = await _suppliersService.ClearAllProductsInCertainSupplier(
                supplier.SupplierId);
            await _orderDetailsService.DeleteOrderDetailAsync(orderDetails.OrderDetailId);
            await _categoryService.DeleteCategoryAsync(category.CategoryId);
            await _shipperService.DeleteShipperAsync(shipper.ShipperId);
            await _paymentService.DeletePaymentAsync(payment.PaymentId);
            await _suppliersService.DeleteSupplierAsync(supplier.SupplierId);
            await _productService.UpdatePrice(product1, 355);
            await _productService.Delete(product2);
        }
    }