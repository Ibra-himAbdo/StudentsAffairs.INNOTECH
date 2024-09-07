using StudentsAffairs.INNOTECH.APIs.Dtos;

namespace StudentsAffairs.INNOTECH.APIs.Dtos.StudentDtos;

public class EnrollmentToReturnWithStudentDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Course { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public List<AttendanceToReturnDto> Attendances { get; set; } = new List<AttendanceToReturnDto>();
}
