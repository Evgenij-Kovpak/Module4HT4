using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Repositories.Abstractions;

public interface IProductRepository
{
    Task<bool> DeleteProductByIdAsync(int id);
    Task<bool> UpdateProductAsync(Product item);
    Task<Product> GetProductByIdAsync(int id);
    Task<int> AddProductAsync(string name, string description, decimal unitPrice, decimal discount, int categoryId, int supplierId);
}
