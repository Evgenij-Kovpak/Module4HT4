using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HT4.Data;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Repositories;

public class OrderDetailsRepository : BaseRepository, IOrderDetailsRepository
{
    public OrderDetailsRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public async Task<int> AddOrderDetailsAsync(decimal price, int orderId, int productId, int? quantity = null, decimal? discount = null)
    {
        var entity = new OrderDetailsEntity()
            { Price = price, OrderId = orderId, ProductId = productId };

        if (discount != null)
        {
            entity.Discount = discount.GetValueOrDefault();
        }

        if (quantity != null)
        {
            entity.Quantity = quantity.GetValueOrDefault();
        }

        DbContext.OrderDetails.Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<OrderDetails> GetOrderDetailsByIdAsync(int id)
    {
        var entity = await DbContext.OrderDetails.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<OrderDetails>(entity);
    }

    public async Task<bool> DeleteOrderDetailsByIdAsync(int id)
    {
        var entity = await DbContext.OrderDetails.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateOrderDetailsAsync(OrderDetails item)
    {
        var entity = await DbContext.OrderDetails.FirstOrDefaultAsync(el => el.Id == item.Id);
        var newEntity = Mapper.Map<OrderDetailsEntity>(item);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
        await DbContext.SaveChangesAsync();

        return true;
    }
}
