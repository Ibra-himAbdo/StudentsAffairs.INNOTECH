

namespace StudentsAffairs.INNOTECH.APIs.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        DepartmentProfiles();
        StudentProfiles();
        ProfessorProfiles();
        EnrollmentProfiles();
        CourseProfiles();
        CreateMap<Attendance, AttendanceToReturnDto>();
    }

    private void CourseProfiles()
    {
        CreateMap<Course, CourseToReturnDto>()
            .ForMember(dest => dest.Department,
                opt => opt.MapFrom(s => s.Department!.Name));
        CreateMap<AddCourseDto, Course>()
            .ForMember(dest => dest.NormalizedName,
                opt => opt.MapFrom(s => s.Name.ToLowerInvariant()));

        CreateMap<UpdateCourseDto, Course>()
            .ForMember(dest => dest.NormalizedName,
                opt => opt.MapFrom(s => s.Name.ToLowerInvariant()));

    }

    private void DepartmentProfiles()
    {
        CreateMap<Department, DepartmentToReturnDto>();

        CreateMap<AddDepartmentDto, Department>()
            .ForMember(dest => dest.NormalizedName,
                opt => opt.MapFrom(s => s.Name.ToLowerInvariant()));

        CreateMap<UpdateDepartmentDto, Department>()
            .ForMember(dest => dest.NormalizedName,
                opt => opt.MapFrom(s => s.Name.ToLowerInvariant()));
    }

    private void EnrollmentProfiles()
    {
        CreateMap<Enrollment, EnrollmentToReturnWithStudentDto>()
            .ForMember(dest => dest.Course, opt => opt.MapFrom(s => s.Course!.Name));
    }

    private void ProfessorProfiles()
    {
        CreateMap<Professor, ProfessorToReturnDto>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(s => s.Department!.Name));

        CreateMap<AddProfessorDto, Professor>()
            .ForMember(dest => dest.NormalizedFullName,
                opt => opt.MapFrom(s => s.FullName.ToLowerInvariant()));

        CreateMap<UpdateProfessorDto, Professor>()
            .ForMember(dest => dest.NormalizedFullName,
                opt => opt.MapFrom(s => s.FullName.ToLowerInvariant()));

    }

    private void StudentProfiles()
    {

        CreateMap<Student, StudentToReturnDto>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(s => s.Department!.Name));

        CreateMap<StudentToCreateDto, Student>()
            .ForMember(dest => dest.NormalizedFullName,
                opt => opt.MapFrom(s => s.FullName.ToLowerInvariant()))
            .ForMember(dest => dest.NormalizedGender,
                opt => opt.MapFrom(s => s.Gender.ToLowerInvariant()))
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth.Date));

        CreateMap<UpdateStudentDto, Student>()
            .ForMember(dest => dest.NormalizedFullName,
                opt => opt.MapFrom(s => s.FullName.ToLowerInvariant()))
            .ForMember(dest => dest.NormalizedGender,
                opt => opt.MapFrom(s => s.Gender.ToLowerInvariant()))
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth.Date));
    }

    private Department MapDepartment(int departmentId)
    {
        var department = new Department
        {
            Id = departmentId
        };

        // Add any additional mapping logic here

        return department;
    }
}
