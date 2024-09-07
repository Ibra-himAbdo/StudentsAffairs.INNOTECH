namespace StudentsAffairs.INNOTECH.Core.Entities;

public class Course : BaseEntity
{
    public string? Name { get; set; }
    public string? NormalizedName { get; set; }
    public string? Code { get; set; }
    public int Credits { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
}
