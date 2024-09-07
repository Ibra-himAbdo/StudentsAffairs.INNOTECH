namespace StudentsAffairs.INNOTECH.Core.Entities;

public class Attendance : BaseEntity
{
    public int EnrollmentId { get; set; }
    public Enrollment? Enrollment { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string? Status { get; set; } // Present/Absent
}
