namespace HW13_1.Entities;

public class TrainingCourseDTO
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public Teacher Teacher { get; set; }
    public int Capacity { get; set; }
}
