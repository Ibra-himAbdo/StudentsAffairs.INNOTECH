namespace StudentsAffairs.INNOTECH.Core.Repositories.Contract;

public interface IEnrollmentRepository : IGenericRepository<Enrollment>
{
    Task<bool> IsEnrollmentExist(Enrollment enrollment);
}
