namespace StudentsAffairs.INNOTECH.Core.Repositories.Contract;

public interface IProfessorRepository : IGenericRepository<Professor>
{
    Task<bool> IsProfessorExist(Professor professor);
}
