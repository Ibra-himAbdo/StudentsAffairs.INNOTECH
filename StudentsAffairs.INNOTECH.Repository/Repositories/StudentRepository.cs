using StudentsAffairs.INNOTECH.Core.Repositories.Contract;
using StudentsAffairs.INNOTECH.Repository.Data;

namespace StudentsAffairs.INNOTECH.Repository.Repositories;

public class StudentRepository(ApplicationDbContext context)
    : GenericRepository<Student>(context), IStudentRepository
{
    public async Task<bool> IsStudentExist(Student student)
        => await ExistsAsync(s =>
            s.NormalizedFullName!.Equals(student.NormalizedFullName) ||
            s.Mobile!.Equals(student.Mobile));
}