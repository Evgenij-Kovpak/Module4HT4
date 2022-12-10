using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HT4.Data;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Repositories;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public async Task<int> AddOrderAsync(int customerId, int paymentId, int shipperId, DateTime? orderDate, DateTime? shipDate = null)
    {
        var entity = new OrderEntity()
        {
            CustomerId = customerId,
            PaymentId = paymentId,
            ShipperId = shipperId,
            OrderDate = orderDate,
            ShipDate = shipDate
        };
        DbContext.Orders.Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var entity = await DbContext.Orders.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<Order>(entity);
    }

    public async Task<bool> DeleteOrderByIdAsync(int id)
    {
        var entity = await DbContext.Orders.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateOrderAsync(Order item)
    {
        var entity = await DbContext.Orders.FirstOrDefaultAsync(el => el.Id == item.Id);
        var newEntity = Mapper.Map<OrderEntity>(item);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Order> GetFullOrderByIdAsync(int id)
    {
        var entity = await DbContext.Orders
            .Include(el => el.OrderDetails)
            .ThenInclude(el => el.Product)
            .Include(el => el.Shipper)
            .Include(el => el.Payment)
            .Include(el => el.Customer)
            .FirstOrDefaultAsync(el => el.Id == id);

        return Mapper.Map<Order>(entity);
    }
}
