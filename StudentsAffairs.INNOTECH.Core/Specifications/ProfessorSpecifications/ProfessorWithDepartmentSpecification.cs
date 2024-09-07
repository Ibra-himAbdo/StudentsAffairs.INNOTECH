namespace StudentsAffairs.INNOTECH.Core.Specifications.ProfessorSpecifications;

public class ProfessorWithDepartmentSpecification : BaseSpecification<Professor>
{
    public ProfessorWithDepartmentSpecification
        (ProfessorSpecificationParams specificationParams)
        : base(P =>
               (string.IsNullOrEmpty(specificationParams.Search) || P.NormalizedFullName!.Contains(specificationParams.Search)) &&
               (!specificationParams.DepartmentId.HasValue || P.DepartmentId.Equals(specificationParams.DepartmentId.Value))
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

        ApplyPagination((specificationParams.PageIndex - 1) * specificationParams.PageSize,
            specificationParams.PageSize);
    }

    public ProfessorWithDepartmentSpecification(int id)
        : base(x => x.Id.Equals(id))
    {
        AddIncludes();
    }

    private void AddIncludes()
    {
        Includes.Add(P => P.Department!);
    }
}
