namespace Texnomart.Data.Interfaces;

public class IUnitOfWork
{
    IUserRepositorie User { get; }
    IOrderRepository Order { get; }
    IProductRepository Product { get; }
    ICategoryRepository Category { get; }
}
