namespace StudentsAffairs.INNOTECH.Core.Specifications.StudentSpecifications;

public class StudentSpecificationParams : SpecificationParams
{
    private string? gender;

    public string? Gender
    {
        get => gender;
        set => gender = value?.ToLowerInvariant();
    }

    //public DateTime? StartDate { get; set; }
    //public DateTime? EndDate { get; set; }

    public int? DepartmentId { get; set; }
    public int? GradeLevel { get; set; }

}
