using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.Interfaces;

public interface IAuthMenager
{
    string GeneratedToken(User user);
}
