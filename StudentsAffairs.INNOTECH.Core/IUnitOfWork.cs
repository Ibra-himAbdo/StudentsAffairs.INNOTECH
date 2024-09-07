namespace StudentsAffairs.INNOTECH.Core;

public interface IUnitOfWork : IAsyncDisposable
{
    IStudentRepository GetStudentRepository();
    IProfessorRepository GetProfessorRepository();
    IEnrollmentRepository GetEnrollmentRepository();
    IDepartmentRepository GetDepartmentRepository();
    ICourseRepository GetCourseRepository();
    IAttendanceRepository GetAttendanceRepository();
    IGenericRepository<T> Repository<T>() where T : BaseEntity;
    Task<int> CompleteAsync();
}
