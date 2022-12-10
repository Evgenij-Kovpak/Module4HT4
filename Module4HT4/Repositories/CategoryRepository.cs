using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Module4HT4.Data;
using Module4HT4.Data.Entities;
using Module4HT4.Models;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Services.Abstractions;

namespace Module4HT4.Repositories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public async Task<int> AddCategoryAsync(string name, string description)
    {
        var entity = new CategoryEntity() { Name = name, Description = description };
        DbContext.Categories.Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var entity = await DbContext.Categories.FirstOrDefaultAsync(el => el.Id == id);
        return Mapper.Map<Category>(entity);
    }

    public async Task<bool> DeleteCategoryByIdAsync(int id)
    {
        var entity = await DbContext.Categories.FirstOrDefaultAsync(el => el.Id == id);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateCategoryAsync(Category item)
    {
        var entity = await DbContext.Categories.FirstOrDefaultAsync(el => el.Id == item.Id);
        var newEntity = Mapper.Map<CategoryEntity>(item);

        if (entity == null)
        {
            return false;
        }

        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
        await DbContext.SaveChangesAsync();

        return true;
    }
}
