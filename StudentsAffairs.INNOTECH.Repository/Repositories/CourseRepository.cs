namespace StudentsAffairs.INNOTECH.Repository.Repositories;

public class CourseRepository(ApplicationDbContext context)
    : GenericRepository<Course>(context), ICourseRepository
{
    public async Task<bool> IsCourseExist(Course course)
        => await ExistsAsync(c => c.NormalizedName!.Equals(course.NormalizedName) ||
               c.Code!.Equals(course.Code));
}
