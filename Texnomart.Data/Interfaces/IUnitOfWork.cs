namespace Texnomart.Data.Interfaces;

public interface IUnitOfWork
{
    IUserRepositorie User { get; }
    IOrderRepository Order { get; }
    IProductRepository Product { get; }
    ICategoryRepository Category { get; }
}
