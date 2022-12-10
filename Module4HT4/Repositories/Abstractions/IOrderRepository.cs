using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Repositories.Abstractions;

public interface IOrderRepository
{
    Task<bool> DeleteOrderByIdAsync(int id);
    Task<bool> UpdateOrderAsync(Order item);
    Task<Order> GetOrderByIdAsync(int id);
    Task<Order> GetFullOrderByIdAsync(int id);
    Task<int> AddOrderAsync(int customerId, int paymentId, int shipperId, DateTime? orderDate, DateTime? shipDate = null);
}
