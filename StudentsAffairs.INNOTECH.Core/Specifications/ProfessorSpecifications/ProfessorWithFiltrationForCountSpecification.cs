namespace StudentsAffairs.INNOTECH.Core.Specifications.ProfessorSpecifications;

public class ProfessorWithFiltrationForCountSpecification : BaseSpecification<Professor>
{
    public ProfessorWithFiltrationForCountSpecification
        (ProfessorSpecificationParams specificationParams)
        : base(P =>
                (string.IsNullOrEmpty(specificationParams.Search) || P.NormalizedFullName!.Contains(specificationParams.Search)) &&
                (!specificationParams.DepartmentId.HasValue || P.DepartmentId.Equals(specificationParams.DepartmentId.Value))
        )
    {
    }
}
