using Texnomart.Domain.Entities;

namespace Texnomart.Data.Interfaces;

public interface IUserRepositorie : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
