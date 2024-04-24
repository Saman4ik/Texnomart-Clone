using Texnomart.Data.DbContextt;
using Texnomart.Data.Interfaces;
using Texnomart.Domain.Entities;

namespace Texnomart.Data.Repositories;

public class ProductRepository(AppDbContext dbContext) : GenericRepository<Product>(dbContext), IProductRepository
{
}
