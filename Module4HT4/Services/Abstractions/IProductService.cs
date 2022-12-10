using Module4HT4.Models;

namespace Module4HT4.Services.Abstractions;

public interface IProductService
{
    Task<int> CreateProduct(string name, string description, decimal unitPrice, decimal discount, int categoryId, int supplierId);
    Task<Product> GetProductById(int id);
}
