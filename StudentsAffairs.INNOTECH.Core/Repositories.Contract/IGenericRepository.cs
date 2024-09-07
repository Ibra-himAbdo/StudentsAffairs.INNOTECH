namespace StudentsAffairs.INNOTECH.Core.Repositories.Contract;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecification<T> specification);
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByIdWithSpecificationAsync(ISpecification<T> specification);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<int> GetCountAsync(ISpecification<T> specification);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}
