namespace StudentsAffairs.INNOTECH.APIs.Dtos.CourseDtos;

public class CourseToReturnDto
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int Credits { get; set; }

    public int? DepartmentId { get; set; }
    public string Department { get; set; } = string.Empty;
}
