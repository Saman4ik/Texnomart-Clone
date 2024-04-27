using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.Interfaces;

public interface IAdminService
{
    Task ChangeUserRoleAsync(int id);
    Task DeleteUserAsync(int id);
    Task<List<User>> GetAllAdminAsync();
}
