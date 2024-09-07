namespace StudentsAffairs.INNOTECH.Core.Repositories.Contract;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<bool> IsCourseExist(Course course);
}