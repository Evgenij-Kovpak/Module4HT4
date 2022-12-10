using Module4HT4.Models;

namespace Module4HT4.Services.Abstractions;

public interface IOrderService
{
    Task<int> CreateOrder(int customerId, int paymentId, int shipperId);
    Task<int?> MakeAnOrder(int customerId, int paymentId, int shipperId, List<OrderDetailsBar> items);
    Task<Order> GetOrderById(int id);
    Task<Order> GetFullOrderById(int id);
}
