namespace StudentsAffairs.INNOTECH.Repository.Repositories;

public class EnrollmentRepository(ApplicationDbContext context)
    : GenericRepository<Enrollment>(context), IEnrollmentRepository
{
    public async Task<bool> IsEnrollmentExist(Enrollment enrollment)
        => await ExistsAsync(e => e.StudentId.Equals(enrollment.StudentId)
                && e.CourseId.Equals(enrollment.CourseId));
}
