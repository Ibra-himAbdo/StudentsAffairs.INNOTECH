namespace StudentsAffairs.INNOTECH.Repository;

public static class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
    {
        var query = inputQuery;
        if (specification.Criteria is not null)
            query = query.Where(specification.Criteria);

        if (specification.OrderBy is not null)
            query = query.OrderBy(specification.OrderBy);

        else if (specification.OrderByDescending is not null)
            query = query.OrderByDescending(specification.OrderByDescending);

        if (specification.IsPaginationEnabled)
            query = query
                .Skip(specification.Skip)
                .Take(specification.Take);

        query = specification.Includes.Aggregate(query, (currentQuery, includeQuery)
                => currentQuery.Include(includeQuery));

        query = specification.IncludeStrings.Aggregate(query, (currentQuery, includeQuery)
                => currentQuery.Include(includeQuery));

        return query;
    }
}
