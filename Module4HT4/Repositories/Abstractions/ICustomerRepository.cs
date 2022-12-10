using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomerAsync(string firstName, string lastName, string? email = null, string? phone = null);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<bool> DeleteCustomerByIdAsync(int id);
        Task<bool> UpdateCustomerAsync(Customer item);
        Task<Customer> GetWithOrdersByIdAsync(int id);
    }
}
