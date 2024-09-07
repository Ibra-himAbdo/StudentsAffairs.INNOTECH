namespace StudentsAffairs.INNOTECH.Core.Specifications.DepartmentSpecifications;

public class DepartmentWithFiltrationForCountSpecification : BaseSpecification<Department>
{
    public DepartmentWithFiltrationForCountSpecification(SpecificationParams specificationParams)
        : base(x =>
            string.IsNullOrEmpty(specificationParams.Search) || x.NormalizedName!.Contains(specificationParams.Search)
        )
    {
    }
}
