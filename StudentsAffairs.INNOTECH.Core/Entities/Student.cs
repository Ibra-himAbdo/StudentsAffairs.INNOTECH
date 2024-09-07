namespace StudentsAffairs.INNOTECH.Core.Entities;

public class Student : BaseEntity
{
    public string? FullName { get; set; }
    public string? NormalizedFullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? NormalizedGender { get; set; }
    public string? Mobile { get; set; }
    public int GradeLevel { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
}
