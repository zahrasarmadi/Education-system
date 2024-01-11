using HW13_1.Entities;

namespace HW13_1.Repository.Interfaces;

public interface IAuthentication
{
    public Person Login(string email, string password);
    public void Register(Person person);
}
