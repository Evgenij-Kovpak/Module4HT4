using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Module4HT4.Data;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IProductService _productService;
        private readonly ILogger<OrderDetailsService> _loggerService;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IProductService productService, ILogger<OrderDetailsService> loggerService)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _productService = productService;
            _loggerService = loggerService;
        }

        public async Task<int> CreateOrderDetails(int orderId, int productId, int? quantity = null, decimal? discount = null)
        {
            var product = await _productService.GetProductById(productId);
            var id = await _orderDetailsRepository.AddOrderDetailsAsync(product.UnitPrice, orderId, productId, quantity, discount);
            _loggerService.LogInformation("Created order details with Id = {Id}", id);

            return id;
        }
    }
}
