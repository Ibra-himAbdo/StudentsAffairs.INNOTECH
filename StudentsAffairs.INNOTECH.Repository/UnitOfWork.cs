namespace StudentsAffairs.INNOTECH.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly Hashtable _repositories;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _repositories = [];
    }

    public IAttendanceRepository GetAttendanceRepository() 
        => GetOrCreateRepository<IAttendanceRepository, AttendanceRepository>();

    public ICourseRepository GetCourseRepository() 
        => GetOrCreateRepository<ICourseRepository, CourseRepository>();

    public IDepartmentRepository GetDepartmentRepository() 
        => GetOrCreateRepository<IDepartmentRepository, DepartmentRepository>();

    public IEnrollmentRepository GetEnrollmentRepository()
        => GetOrCreateRepository<IEnrollmentRepository, EnrollmentRepository>();

    public IProfessorRepository GetProfessorRepository() 
        => GetOrCreateRepository<IProfessorRepository, ProfessorRepository>();

    public IStudentRepository GetStudentRepository() 
        => GetOrCreateRepository<IStudentRepository, StudentRepository>();

    public IGenericRepository<T> Repository<T>() where T : BaseEntity 
        => GetOrCreateRepository<IGenericRepository<T>, GenericRepository<T>>();

    private TRepo GetOrCreateRepository<TRepo, TConcreteRepo>()
        where TConcreteRepo : TRepo
    {
        var key = typeof(TRepo).FullName;

        if (!_repositories.ContainsKey(key!))
        {
            var repository = (TRepo)Activator.CreateInstance(typeof(TConcreteRepo), _context)!;
            _repositories.Add(key!, repository);
        }

        return (TRepo)_repositories[key!]!;
    }

    public async Task<int> CompleteAsync()
    => await _context.SaveChangesAsync();

    public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();
}
