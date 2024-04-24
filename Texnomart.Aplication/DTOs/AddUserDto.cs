using Texnomart.Domain.Entities;
using Texnomart.Domain.Enums;

namespace Texnomart.Aplication.DTOs;

public class AddUserDto
{
    public string FrisName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Gender Gender { get; set; }

    public static implicit operator User(AddUserDto dto)
    {
        return new User
        {
            FrisName = dto.FrisName,
            LastName = dto.LastName,
            Address = dto.Address,
            Email = dto.Email,
            Gender = dto.Gender,
            Password = dto.Password
        };

    }
}
