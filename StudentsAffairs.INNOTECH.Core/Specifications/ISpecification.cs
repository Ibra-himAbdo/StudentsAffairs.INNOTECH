namespace StudentsAffairs.INNOTECH.Core.Specifications;

public interface ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; }
    public List<string> IncludeStrings { get; }

    public Expression<Func<T, object>>? OrderBy { get; }
    public Expression<Func<T, object>>? OrderByDescending { get; }

    public int Skip { get; }
    public int Take { get; }
    public bool IsPaginationEnabled { get; }
}
