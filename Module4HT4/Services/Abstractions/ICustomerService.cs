using Module4HT4.Models;

namespace Module4HT4.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<int> CreateCustomer(string firstName, string lastName);
        Task<Customer> GetCustomer(int id);
        Task<Customer> GetCustomerWithOrders(int id);
    }
}
