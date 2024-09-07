namespace StudentsAffairs.INNOTECH.Core.Entities;

public class Enrollment : BaseEntity
{
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public string? Grade { get; set; } // A, B, C, D, F
    public DateTime EnrollmentDate { get; set; }

    public List<Attendance> Attendances { get; set; } = new List<Attendance>();

}
