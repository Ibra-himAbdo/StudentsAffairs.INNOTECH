namespace StudentsAffairs.INNOTECH.Core.Specifications.DepartmentSpecifications;

public class DepartmentSpecifications : BaseSpecification<Department>
{
    public DepartmentSpecifications(SpecificationParams specificationParams)
        : base(x =>
            string.IsNullOrEmpty(specificationParams.Search) || x.NormalizedName!.Contains(specificationParams.Search)
        )
    {

        if (!string.IsNullOrEmpty(specificationParams.Sort))
            switch (specificationParams.Sort)
            {
                case "nameDesc":
                    AddOrderByDescending(S => S.Name!);
                    break;
                default:
                    AddOrderBy(S => S.Name!);
                    break;
            }
        else
            AddOrderBy(S => S.Name!);

        ApplyPagination(
            specificationParams.PageSize * (specificationParams.PageIndex - 1),
            specificationParams.PageSize);
    }


    public DepartmentSpecifications(int id)
        : base(x => x.Id.Equals(id))
    {
    }


}
