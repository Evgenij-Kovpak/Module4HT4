using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Repositories.Abstractions;

public interface ISupplierRepository
{
    Task<bool> DeleteSupplierByIdAsync(int id);
    Task<bool> UpdateSupplierAsync(Supplier item);
    Task<Supplier> GetSupplierByIdAsync(int id);
    Task<int> AddSupplierAsync(string companyName, string contactFName, string contactLName, int customerId, string? phone = null);
}
