using Texnomart.Domain.Entities;

namespace Texnomart.Data.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product> GetByNameAsync(string name);
}