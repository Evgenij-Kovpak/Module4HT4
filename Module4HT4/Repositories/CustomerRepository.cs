using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HT4.Data;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Repositories;

public class CustomerRepository : BaseRepository, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public async Task<int> AddCustomerAsync(string firstName, string lastName, string? email, string? phone)
    {
        var entity = new CustomerEntity()
            { FirstName = firstName, LastName = lastName, Phone = phone, Email = email };
        DbContext.Customers.Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        var entity = await DbContext.Customers.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<Customer>(entity);
    }

    public async Task<bool> DeleteCustomerByIdAsync(int id)
    {
        var entity = await DbContext.Customers.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateCustomerAsync(Customer item)
    {
        var entity = await DbContext.Customers.FirstOrDefaultAsync(el => el.Id == item.Id);
        var newEntity = Mapper.Map<CustomerEntity>(item);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Customer> GetWithOrdersByIdAsync(int id)
    {
        var entity = await DbContext.Customers.Include(el => el.Orders).FirstOrDefaultAsync(el => el.Id == id);

        return Mapper.Map<Customer>(entity);
    }
}
