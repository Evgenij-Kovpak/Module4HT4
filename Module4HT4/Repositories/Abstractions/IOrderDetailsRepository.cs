using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Repositories.Abstractions;

public interface IOrderDetailsRepository
{
    Task<int> AddOrderDetailsAsync(decimal price, int orderId, int productId, int? quantity = null, decimal? discount = null);
    Task<OrderDetails> GetOrderDetailsByIdAsync(int id);
    Task<bool> DeleteOrderDetailsByIdAsync(int id);
    Task<bool> UpdateOrderDetailsAsync(OrderDetails item);
}
