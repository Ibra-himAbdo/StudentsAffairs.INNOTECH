using System.Text.Json;

namespace StudentsAffairs.INNOTECH.Repository.Data;

public static class ApplicationContextSeed
{
    static readonly string _dataPath =
        Path.Combine("..", "StudentsAffairs.INNOTECH.Repository", "Data", "DataSeed");

    static readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    public static async Task SeedDataAsync(ApplicationDbContext context)
    {
        if (!await context.Departments.AnyAsync())
        {
            var departments = await GetDataFromJsonFile<Department>("departments.json");
            if (departments?.Count > 0)
                foreach (var department in departments)
                {
                    department.NormalizedName = department.Name!.ToLowerInvariant();
                    context.Departments.Add(department);
                }


            await context.SaveChangesAsync();
        }

        if (!await context.Professors.AnyAsync())
        {
            var professors = await GetDataFromJsonFile<Professor>("professors.json");
            if (professors?.Count > 0)
                foreach (var professor in professors)
                {
                    professor.NormalizedFullName = professor.FullName!.ToLowerInvariant();
                    context.Professors.Add(professor);
                }


            await context.SaveChangesAsync();
        }

        if (!await context.Students.AnyAsync())
        {
            var students = await GetDataFromJsonFile<Student>("students.json");
            if (students?.Count > 0)
                foreach (var student in students)
                {
                    student.NormalizedFullName = student.FullName!.ToLowerInvariant();
                    student.NormalizedGender = student.Gender!.ToLowerInvariant();
                    context.Students.Add(student);
                }

            await context.SaveChangesAsync();
        }

        if (!await context.Courses.AnyAsync())
        {
            var courses = await GetDataFromJsonFile<Course>("courses.json");

            if (courses?.Count > 0)
                foreach (var course in courses)
                {
                    course.NormalizedName = course.Name!.ToLowerInvariant();
                    context.Courses.Add(course);
                }


            await context.SaveChangesAsync();
        }

        if (!await context.Enrollments.AnyAsync())
        {
            var enrollments = await GetDataFromJsonFile<Enrollment>("enrollments.json");
            if (enrollments?.Count > 0)
                foreach (var enrollment in enrollments)
                    context.Enrollments.Add(enrollment);
            await context.SaveChangesAsync();
        }

        if (!await context.Attendances.AnyAsync())
        {
            var attendances = await GetDataFromJsonFile<Attendance>("attendances.json");
            if (attendances?.Count > 0)
                foreach (var attendance in attendances)
                    context.Attendances.Add(attendance);
            await context.SaveChangesAsync();
        }

    }

    private static async Task<List<T>> GetDataFromJsonFile<T>(string fileName)
    {
        var filePath = Path.Combine(_dataPath, fileName);
        if (!File.Exists(filePath))
            return [];

        string data = await File.ReadAllTextAsync(filePath);

        var result = JsonSerializer.Deserialize<List<T>>(data, _options);
        return result ?? [];
    }
}
