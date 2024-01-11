using HW13_1.Enum;

namespace HW13_1.Entities;

public class RegisterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
}