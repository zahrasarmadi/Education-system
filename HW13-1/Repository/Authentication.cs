using HW13_1.Entities;
using HW13_1.Repository.Interfaces;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;
using HW13_1.Repository;

namespace HW13_1.Repository;

public class Authentication : IAuthentication
{
    Serialization serializationST = new Serialization("student.json");
    Serialization serializationTR = new Serialization("teacher.json");
    public Person Login(LoginDTO loginDTO)
    {
        Database.teachers = serializationTR.ReadFromFile<Teacher>();
        Database.students = serializationST.ReadFromFile<Student>();
        var loginTeacher = Database.teachers.FirstOrDefault(p => p.Email == loginDTO.Email && p.Password == loginDTO.Password);
        var loginStudebt = Database.students.FirstOrDefault(p => p.Email == loginDTO.Email && p.Password == loginDTO.Password);
        if (loginStudebt != null && loginTeacher == null)
        {
            return loginStudebt;
        }
        else if (loginStudebt == null && loginTeacher != null)
        {
            return loginTeacher;
        }
        throw new Exception();

    }

    public void Register(Person person)
    {
        Database.teachers = serializationTR.ReadFromFile<Teacher>();
        Database.students = serializationST.ReadFromFile<Student>();
        if (person.Role == Enum.RoleEnum.Teacher)
        {
            var teacher = new Teacher()
            {
                Email = person.Email,
                Password = person.Password,
                Role = person.Role,
                FirstName = person.FirstName,
                LastName = person.LastName,
            };
            
            Database.teachers.Add(teacher);
            serializationTR.SaveToFileWhitWrite(Database.teachers);
        }
        else if (person.Role == Enum.RoleEnum.Student)
        {
            var student = new Student()
            {
                Email = person.Email,
                Password = person.Password,
                Role = person.Role,
                FirstName = person.FirstName,
                LastName = person.LastName,
            };
            Database.students.Add(student);
            serializationST.SaveToFileWhitWrite(Database.students);
        }
    }
}
