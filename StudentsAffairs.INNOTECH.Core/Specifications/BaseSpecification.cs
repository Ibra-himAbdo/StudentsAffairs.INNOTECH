namespace StudentsAffairs.INNOTECH.Core.Specifications;

public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; protected set; }
    public List<Expression<Func<T, object>>> Includes { get; protected set; } = [];
    public List<string> IncludeStrings { get; protected set; } = [];
    public Expression<Func<T, object>>? OrderBy { get; protected set; }
    public Expression<Func<T, object>>? OrderByDescending { get; protected set; }
    public int Skip { get; protected set; }
    public int Take { get; protected set; }
    public bool IsPaginationEnabled { get; protected set; }

    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> criteria) => Criteria = criteria;

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        => OrderBy = orderByExpression;

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        => OrderByDescending = orderByDescExpression;

    protected void ApplyPagination(int skip, int take)
    {
        IsPaginationEnabled = true;
        Skip = skip;
        Take = take;
    }
}
