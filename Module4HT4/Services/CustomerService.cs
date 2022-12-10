using Microsoft.Extensions.Logging;
using Module4HT4.Data;
using Module4HT4.Models;
using Module4HT4.Repositories;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _loggerService;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> loggerService)
        {
            _customerRepository = customerRepository;
            _loggerService = loggerService;
        }

        public async Task<int> CreateCustomer(string firstName, string lastName)
        {
            var id = await _customerRepository.AddCustomerAsync(firstName, lastName);
            _loggerService.LogInformation("Created customer with Id = {Id}", id);

            return id;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var item = await _customerRepository.GetCustomerByIdAsync(id);

            if (item == null)
            {
                _loggerService.LogWarning("Not founded customer with Id = {Id}", id);
            }

            return item!;
        }

        public async Task<Customer> GetCustomerWithOrders(int id)
        {
            var item = await _customerRepository.GetWithOrdersByIdAsync(id);

            if (item == null)
            {
                _loggerService.LogWarning("Not founded customer with Id = {Id}", id);
            }

            return item!;
        }
    }
}
