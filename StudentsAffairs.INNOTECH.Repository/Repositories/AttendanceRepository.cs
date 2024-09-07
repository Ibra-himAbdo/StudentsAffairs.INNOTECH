namespace StudentsAffairs.INNOTECH.Repository.Repositories;

public class AttendanceRepository(ApplicationDbContext context)
    : GenericRepository<Attendance>(context), IAttendanceRepository
{
    public async Task<bool> IsAttendanceExist(Attendance attendance)
        => await ExistsAsync(a => a.EnrollmentId.Equals(attendance.EnrollmentId) &&
                a.AttendanceDate.Equals(attendance.AttendanceDate));
}
