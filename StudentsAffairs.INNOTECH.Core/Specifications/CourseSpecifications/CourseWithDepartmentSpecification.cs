namespace StudentsAffairs.INNOTECH.Core.Specifications.CourseSpecifications;

public class CourseWithDepartmentSpecification : BaseSpecification<Course>
{

    public CourseWithDepartmentSpecification(CourseSpecificationParams specificationParams)
        : base(x =>
            (string.IsNullOrEmpty(specificationParams.Search) || x.NormalizedName!.Contains(specificationParams.Search)) &&
            (!specificationParams.DepartmentId.HasValue || x.DepartmentId.Equals(specificationParams.DepartmentId)) &&
            (!specificationParams.Credits.HasValue || x.Credits.Equals(specificationParams.Credits)) &&
            (string.IsNullOrEmpty(specificationParams.Code) || x.Code!.Contains(specificationParams.Code))
        )
    {
        AddInclude();
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
                    AddOrderByDescending(S => S.Name!);
                    break;
                default:
                    AddOrderBy(S => S.Name!);
                    break;
            }
        else
            AddOrderBy(S => S.Name!);

        ApplyPagination((specificationParams.PageIndex - 1) * specificationParams.PageSize,
            specificationParams.PageSize);
    }

    public CourseWithDepartmentSpecification(int id)
        : base(x => x.Id == id)
    {
        AddInclude();
    }

    private void AddInclude()
    {
        Includes.Add(C => C.Department!);
    }

}
