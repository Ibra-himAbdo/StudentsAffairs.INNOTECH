namespace StudentsAffairs.INNOTECH.Core.Specifications.AttendanceSpecifications;

public class AttendanceWithEnrollmentSpecification : BaseSpecification<Attendance>
{
    public AttendanceWithEnrollmentSpecification()
        : base(x => true)
    {
    }


    public AttendanceWithEnrollmentSpecification(int id)
        : base(x => x.Id == id)
    {
    }
}