using Microsoft.EntityFrameworkCore;
using Texnomart.Data.DbContextt;
using Texnomart.Data.Interfaces;
using Texnomart.Domain.Entities;

namespace Texnomart.Data.Repositories;

public class ProductRepository(AppDbContext dbContext) : GenericRepository<Product>(dbContext), IProductRepository
{
    public async Task<Product> GetByNameAsync(string name){
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.Name == name) ?? new();
    }
        
}
