using Texnomart.Domain.Enums;

namespace Texnomart.Domain.Entities;

public class User : BaseEntity
{
    public string FrisName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsVerified { get; set; } = false;
    public Gender Gender { get; set; }
    public Role Role { get; set; }
}
