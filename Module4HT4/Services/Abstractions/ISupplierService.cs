using Module4HT4.Models;

namespace Module4HT4.Services.Abstractions;

public interface ISupplierService
{
    Task<int> CreateSupplier(string companyName, string firstName, string lastName, int customerId);
}
