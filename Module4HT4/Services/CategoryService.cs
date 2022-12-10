using Microsoft.Extensions.Logging;
using Module4HT4.Data;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _loggerService;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> loggerService)
        {
            _categoryRepository = categoryRepository;
            _loggerService = loggerService;
        }

        public async Task<int> CreateCategory(string name, string description)
        {
            var id = await _categoryRepository.AddCategoryAsync(name, description);
            _loggerService.LogInformation("Created category with Id = {Id}", id);

            return id;
        }

        public async Task<Category> GetCategory(int id)
        {
            var item = await _categoryRepository.GetCategoryByIdAsync(id);

            if (item == null)
            {
                _loggerService.LogWarning("Not founded Category with Id = {Id}", id);
            }

            return item!;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var result = await _categoryRepository.DeleteCategoryByIdAsync(id);
            _loggerService.LogInformation("Deleted category with Id = {Id}", id);

            return result;
        }

        public async Task<bool> UpdateCategory(Category item)
        {
            var result = await _categoryRepository.UpdateCategoryAsync(item);
            _loggerService.LogInformation("Updated category with Id = {Id}", item.Id);

            return result;
        }
    }
}
