using Microsoft.EntityFrameworkCore;
using Module4HT4.Data;
using Module4HT4.Services.Abstractions;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using AutoMapper;

namespace Module4HT4.Repositories
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<int> AddSupplierAsync(string companyName, string contactFName, string contactLName, int customerId, string? phone = null)
        {
            var entity = new SupplierEntity()
            {
                CompanyName = companyName,
                ContactFName = contactFName,
                ContactLName = contactLName,
                CustomerId = customerId,
                Phone = phone
            };

            DbContext.Suppliers.Add(entity);
            await DbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            var entity = await DbContext.Suppliers.FirstOrDefaultAsync(el => el.Id == id);
            return Mapper.Map<Supplier>(entity);
        }

        public async Task<bool> DeleteSupplierByIdAsync(int id)
        {
            var entity = await DbContext.Suppliers.FirstOrDefaultAsync(el => el.Id == id);

            if (entity == null)
            {
                return false;
            }

            DbContext.Entry(entity).State = EntityState.Deleted;
            await DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateSupplierAsync(Supplier item)
        {
            var entity = await DbContext.Suppliers.FirstOrDefaultAsync(el => el.Id == item.Id);
            var newEntity = Mapper.Map<SupplierEntity>(item);

            if (entity == null)
            {
                return false;
            }

            DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
