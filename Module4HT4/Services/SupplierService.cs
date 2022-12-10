using Module4HT4.Data;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Module4HT4.Models;
using Module4HT4.Repositories;

namespace Module4HT4.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ILogger<SupplierService> _loggerService;

        public SupplierService(ISupplierRepository supplierRepository, ILogger<SupplierService> loggerService)
        {
            _supplierRepository = supplierRepository;
            _loggerService = loggerService;
        }

        public async Task<int> CreateSupplier(string companyName, string firstName, string lastName, int customerId)
        {
            var id = await _supplierRepository.AddSupplierAsync(companyName, firstName, lastName, customerId);
            _loggerService.LogInformation("Created supplier with Id = {Id}", id);

            return id;
        }
    }
}
