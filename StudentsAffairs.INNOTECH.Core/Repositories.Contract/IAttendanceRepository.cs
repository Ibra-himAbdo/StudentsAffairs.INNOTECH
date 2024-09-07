namespace StudentsAffairs.INNOTECH.Core.Repositories.Contract;

public interface IAttendanceRepository : IGenericRepository<Attendance>
{
    Task<bool> IsAttendanceExist(Attendance attendance);
}
