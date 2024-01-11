using HW13_1.Entities;
using HW13_1.Repository.Interfaces;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;
using HW13_1.Repository;

namespace HW13_1.Repository;

public class Authentication : IAuthentication
{
    Serialization serialization = new Serialization("person.json");
    public Person Login(string email, string password)
    {
        Database.people = serialization.ReadFromFile<Person>();

        var loginPerson = Database.people.FirstOrDefault(p => p.Email == email && p.Password == password);
        if (loginPerson != null)
        {
            if (loginPerson.Role == Enum.RoleEnum.Student)
            {
                return (Student)loginPerson;
            }
            else if (loginPerson.Role == Enum.RoleEnum.Professor)
            {
                return (Teacher)loginPerson;
            }
        }
        return null;
    }

    public void Register(RegisterDTO person)
    {
        Database.people.Add(person);
        serialization.SaveToFileWhitWrite(Database.people);
    }
}
