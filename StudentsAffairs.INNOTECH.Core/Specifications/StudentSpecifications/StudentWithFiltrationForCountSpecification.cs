namespace StudentsAffairs.INNOTECH.Core.Specifications.StudentSpecifications;

public class StudentWithFiltrationForCountSpecification
    : BaseSpecification<Student>
{
    public StudentWithFiltrationForCountSpecification(StudentSpecificationParams specificationParams) :
        base(S =>
            (!specificationParams.DepartmentId.HasValue || S.DepartmentId.Equals(specificationParams.DepartmentId)) &&
            (!specificationParams.GradeLevel.HasValue || S.GradeLevel.Equals(specificationParams.GradeLevel)) &&
            (string.IsNullOrEmpty(specificationParams.Search) || S.NormalizedFullName!.Contains(specificationParams.Search)) &&
            (string.IsNullOrEmpty(specificationParams.Gender) || S.NormalizedGender!.Equals(specificationParams.Gender))
        )
    {

    }
}
