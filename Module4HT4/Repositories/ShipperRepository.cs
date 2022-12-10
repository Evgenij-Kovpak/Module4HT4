using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HT4.Data;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Repositories
{
    public class ShipperRepository : BaseRepository, IShipperRepository
    {
        public ShipperRepository(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<int> AddShipperAsync(string companyName, string phone)
        {
            var entity = new ShipperEntity() { CompanyName = companyName, Phone = phone };
            DbContext.Shippers.Add(entity);
            await DbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Shipper> GetShipperByIdAsync(int id)
        {
            var entity = await DbContext.Shippers.FirstOrDefaultAsync(el => el.Id == id);
            return Mapper.Map<Shipper>(entity);
        }

        public async Task<bool> DeleteShipperByIdAsync(int id)
        {
            var entity = await DbContext.Shippers.FirstOrDefaultAsync(el => el.Id == id);

            if (entity == null)
            {
                return false;
            }

            DbContext.Entry(entity).State = EntityState.Deleted;
            await DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateShipperAsync(Shipper item)
        {
            var entity = await DbContext.Shippers.FirstOrDefaultAsync(el => el.Id == item.Id);
            var newEntity = Mapper.Map<ShipperEntity>(item);

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
