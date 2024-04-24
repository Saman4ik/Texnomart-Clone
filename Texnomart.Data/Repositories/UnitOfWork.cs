using Texnomart.Data.DbContextt;
using Texnomart.Data.Interfaces;

namespace Texnomart.Data.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public IUserRepositorie User => new UserRepository(_appDbContext);
    public IOrderRepository Order => new OrderRepository(_appDbContext);
    public ICategoryRepository Category => new CategoryRepository(_appDbContext);
    public IProductRepository Product => new ProductRepository(_appDbContext);
}
