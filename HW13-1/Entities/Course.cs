namespace HW13_1.Entities;
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long Grade { get; set; }
    public Teacher Teacher { get; set; }
}