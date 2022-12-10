using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Module4HT4.Data;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using Module4HT4.Repositories;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<PaymentService> _loggerService;

        public PaymentService(IPaymentRepository paymentRepository, ILogger<PaymentService> loggerService)
        {
            _paymentRepository = paymentRepository;
            _loggerService = loggerService;
        }

        public async Task<int> CreatePayment(string? type = null)
        {
            var id = await _paymentRepository.AddPaymentAsync(type);
            _loggerService.LogInformation("Created payment with Id = {Id}", id);

            return id;
        }
    }
}
