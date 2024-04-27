using Texnomart.Data.DbContextt;
using Texnomart.Data.Interfaces;
using Texnomart.Domain.Entities;

namespace Texnomart.Data.Repositories;

public class CategoryRepository(AppDbContext dbContext) : GenericRepository<Category>(dbContext), ICategoryRepository
{
    public async Task<bool> IsCategoryExistsAsync(string categoryName)
    {
        var category = await _dbContext.Categories.FindAsync(categoryName);
        return category != null;
    }
}
