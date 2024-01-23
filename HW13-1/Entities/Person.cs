using HW13_1.Enum;
using HW13_1.Repository;

namespace HW13_1.Entities;
public class Person
{
    public int Id { get; set; } = Database.PersonCounter++;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
}