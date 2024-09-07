namespace StudentsAffairs.INNOTECH.Core.Specifications.CourseSpecifications;

public class CourseWithFiltrationForCountSpecification : BaseSpecification<Course>
{
    public CourseWithFiltrationForCountSpecification(CourseSpecificationParams specificationParams)
    : base(x =>
        (string.IsNullOrEmpty(specificationParams.Search) || x.NormalizedName!.Contains(specificationParams.Search)) &&
        (!specificationParams.DepartmentId.HasValue || x.DepartmentId.Equals(specificationParams.DepartmentId)) &&
        (!specificationParams.Credits.HasValue || x.Credits.Equals(specificationParams.Credits)) &&
        (string.IsNullOrEmpty(specificationParams.Code) || x.Code!.Contains(specificationParams.Code))
    )
    {
    }
}