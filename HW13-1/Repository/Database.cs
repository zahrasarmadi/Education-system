using HW13_1.Entities;

namespace HW13_1.Repository;

public static class Database
{
    public static List<Student> students = new List<Student>();
    public static List<Teacher> teachers = new List<Teacher>();
    public static Student OnlineStudent = new Student();
    public static Teacher OnlineTeacher = new Teacher();
}
