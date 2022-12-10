using Module4HT4.Data.Entities;
using Module4HT4.Models;

namespace Module4HT4.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryAsync(string name, string description);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> DeleteCategoryByIdAsync(int id);
        Task<bool> UpdateCategoryAsync(Category item);
    }
}
