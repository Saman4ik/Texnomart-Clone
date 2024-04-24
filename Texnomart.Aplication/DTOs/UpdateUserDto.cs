using Texnomart.Domain.Entities;
using Texnomart.Domain.Enums;

namespace Texnomart.Aplication.DTOs;

public class UpdateUserDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Address { get; set; } = "";
    public string Email { get; set; } = "";
    public Gender Gender { get; set; }

    public static implicit operator User(UpdateUserDto dto)
    {
        return new User()
        {
            FrisName = dto.FirstName,
            LastName = dto.LastName,
            Address = dto.Address,
            Email = dto.Email,
            Gender = dto.Gender,
        };
    }
}
