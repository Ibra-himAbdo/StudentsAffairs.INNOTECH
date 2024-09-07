namespace StudentsAffairs.INNOTECH.Core.Specifications.StudentSpecifications;

public class StudentWithEnrollmentsAndDepartmentSpecification : BaseSpecification<Student>
{
    public StudentWithEnrollmentsAndDepartmentSpecification
        (StudentSpecificationParams specificationParams)
        : base(S =>
            (!specificationParams.DepartmentId.HasValue || S.DepartmentId.Equals(specificationParams.DepartmentId)) &&
            (!specificationParams.GradeLevel.HasValue || S.GradeLevel.Equals(specificationParams.GradeLevel)) &&
            (string.IsNullOrEmpty(specificationParams.Search) || S.NormalizedFullName!.Contains(specificationParams.Search)) &&
            (string.IsNullOrEmpty(specificationParams.Gender) || S.NormalizedGender!.Equals(specificationParams.Gender))

        )
    {
        AddIncludes();

        if (!string.IsNullOrEmpty(specificationParams.Sort))
            switch (specificationParams.Sort)
            {
                case "departAsc":
                    AddOrderBy(S => S.Department!.Name!);
                    break;
                case "departDesc":
                    AddOrderByDescending(S => S.Department!.Name!);
                    break;
                case "nameDesc":
                    AddOrderByDescending(S => S.FullName!);
                    break;
                default:
                    AddOrderBy(S => S.FullName!);
                    break;
            }
        else
            AddOrderBy(S => S.FullName!);

        ApplyPagination(
            specificationParams.PageSize * (specificationParams.PageIndex - 1),
            specificationParams.PageSize);
    }


    public StudentWithEnrollmentsAndDepartmentSpecification(int id)
        : base(S => S.Id.Equals(id))
    {
        AddIncludes();
    }
    private void AddIncludes()
    {
        Includes.Add(S => S.Department!);
        Includes.Add(S => S.Enrollments!);
        IncludeStrings.Add($"{nameof(Student.Enrollments)}.{nameof(Enrollment.Course)}");
        IncludeStrings.Add($"{nameof(Student.Enrollments)}.{nameof(Enrollment.Attendances)}");
    }
}
