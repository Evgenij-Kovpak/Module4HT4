using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Repositories.Abstractions;

public interface IShipperRepository
{
    Task<bool> DeleteShipperByIdAsync(int id);
    Task<bool> UpdateShipperAsync(Shipper item);
    Task<Shipper> GetShipperByIdAsync(int id);
    Task<int> AddShipperAsync(string companyName, string phone);
}
