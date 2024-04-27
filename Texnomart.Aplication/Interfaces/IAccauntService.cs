using Texnomart.Aplication.DTOs.UserDTOs;

namespace Texnomart.Aplication.Interfaces;

public interface IAccauntService
{
    Task<bool> RegistrAsync(AddUserDto dto);
    Task<string> LoginAsync(LoginDto login);
    Task SendCodeAsync(string email);
    Task<bool> CheckCodeAsync(string email, string code);
}
