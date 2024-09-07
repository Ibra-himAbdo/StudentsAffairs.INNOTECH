namespace StudentsAffairs.INNOTECH.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context) 
        => _context = context;

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
        => _context.Set<T>().Remove(entity);

    public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

    public async Task<IReadOnlyList<T>> GetAllWithSpecificationAsync
        (ISpecification<T> specification)
        => await ApplySpecification(specification).AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

    public async Task<T?> GetByIdWithSpecificationAsync(ISpecification<T> specification)
        => await ApplySpecification(specification).AsNoTracking().FirstOrDefaultAsync();

    public async Task<int> GetCountAsync(ISpecification<T> specification)
        => await ApplySpecification(specification).AsNoTracking().CountAsync();

    public void Update(T entity)
         => _context.Set<T>().Update(entity);

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().AnyAsync(predicate);

    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        => SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), specification);

    


}
