using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.DTOs.UserDTOs;

public class UserDto : AddUserDto
{
    public int Id { get; set; }


    public static implicit operator UserDto(User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            FrisName = user.FrisName,
            LastName = user.LastName,
            Address = user.Address,
            Email = user.Email,
            Password = user.Password,
            Gender = user.Gender
        };
    }
}
