namespace StudentsAffairs.INNOTECH.Core.Entities;

public class Professor : BaseEntity
{
    public string? FullName { get; set; }
    public string? NormalizedFullName { get; set; }
    public string? Mobile { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
}
