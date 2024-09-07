namespace StudentsAffairs.INNOTECH.APIs.Dtos.StudentDtos;

public class StudentToReturnDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public int GradeLevel { get; set; }
    public int? DepartmentId { get; set; }
    public string Department { get; set; } = string.Empty;
    public ICollection<EnrollmentToReturnWithStudentDto> Enrollments { get; set; } = new HashSet<EnrollmentToReturnWithStudentDto>();

}
