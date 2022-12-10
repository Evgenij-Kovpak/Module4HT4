using Microsoft.Extensions.Logging;
using Module4HT4.Data;
using Module4HT4.Models;
using Module4HT4.Repositories;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly ILogger<ShipperService> _loggerService;

        public ShipperService(IShipperRepository shipperRepository, ILogger<ShipperService> loggerService)
        {
            _shipperRepository = shipperRepository;
            _loggerService = loggerService;
        }

        public async Task<int> CreateShipper(string name, string phone)
        {
            var id = await _shipperRepository.AddShipperAsync(name, phone);
            _loggerService.LogInformation("Created shipper with Id = {Id}", id);

            return id;
        }
    }
}
