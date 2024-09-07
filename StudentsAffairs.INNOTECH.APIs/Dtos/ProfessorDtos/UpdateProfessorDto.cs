namespace StudentsAffairs.INNOTECH.APIs.Dtos.ProfessorDtos;

public class UpdateProfessorDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
}
