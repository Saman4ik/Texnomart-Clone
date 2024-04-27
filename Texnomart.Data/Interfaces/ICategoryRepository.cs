using Texnomart.Domain.Entities;

namespace Texnomart.Data.Interfaces;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<bool> IsCategoryExistsAsync(string categoryName);
}
