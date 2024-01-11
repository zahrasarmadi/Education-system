using HW13_1.Entities;

namespace HW13_1.Repository.Interfaces;

public interface IAuthentication
{
    public Person Login(LoginDTO loginDTO);
    public void Register(Person person);
}
