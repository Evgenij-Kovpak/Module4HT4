using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Repositories.Abstractions;

public interface IPaymentRepository
{
    Task<bool> DeletePaymentByIdAsync(int id);
    Task<bool> UpdatePaymentAsync(Payment item);
    Task<Payment> GetPaymentByIdAsync(int id);
    Task<int> AddPaymentAsync(string? type = null, bool? allowed = null);
}
