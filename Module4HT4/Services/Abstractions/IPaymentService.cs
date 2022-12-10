using Module4HT4.Models;

namespace Module4HT4.Services.Abstractions;

public interface IPaymentService
{
    Task<int> CreatePayment(string? type = null);
}
