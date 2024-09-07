namespace StudentsAffairs.INNOTECH.APIs.Dtos.ProfessorDtos;

public class AddProfessorDto
{
    public string FullName { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
}
