using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HT4.Data;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Repositories;

public class PaymentRepository : BaseRepository, IPaymentRepository
{
    public PaymentRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public async Task<int> AddPaymentAsync(string? type = null, bool? allowed = null)
    {
        var entity = new PaymentEntity() { Type = type! };

        if (allowed != null)
        {
            entity.Allowed = allowed.GetValueOrDefault();
        }

        DbContext.Payments.Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Payment> GetPaymentByIdAsync(int id)
    {
        var entity = await DbContext.Payments.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<Payment>(entity);
    }

    public async Task<bool> DeletePaymentByIdAsync(int id)
    {
        var entity = await DbContext.Payments.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdatePaymentAsync(Payment item)
    {
        var entity = await DbContext.Payments.FirstOrDefaultAsync(el => el.Id == item.Id);
        var newEntity = Mapper.Map<PaymentEntity>(item);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
        await DbContext.SaveChangesAsync();

        return true;
    }
}
