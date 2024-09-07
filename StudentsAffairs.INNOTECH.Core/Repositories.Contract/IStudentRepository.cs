namespace StudentsAffairs.INNOTECH.Core.Repositories.Contract;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<bool> IsStudentExist(Student student);
}
