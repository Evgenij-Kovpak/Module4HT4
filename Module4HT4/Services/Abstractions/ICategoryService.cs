using Module4HT4.Models;

namespace Module4HT4.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<int> CreateCategory(string name, string description);
        Task<Category> GetCategory(int id);
        Task<bool> DeleteCategory(int id);
        Task<bool> UpdateCategory(Category item);
    }
}
