namespace StudentsAffairs.INNOTECH.Core.Specifications.CourseSpecifications;

public class CourseSpecificationParams : SpecificationParams
{
    public int? DepartmentId { get; set; }
    public int? Credits { get; set; }
    private string? _code;

    public string? Code
    {
        get => _code;
        set => _code = value?.ToUpperInvariant();
    }

}
