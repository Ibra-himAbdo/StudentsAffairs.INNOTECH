namespace StudentsAffairs.INNOTECH.APIs.Dtos.CourseDtos;

public class AddCourseDto
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int Credits { get; set; }
    public int DepartmentId { get; set; }
}
