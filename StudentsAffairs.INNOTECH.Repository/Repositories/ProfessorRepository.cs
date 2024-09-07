namespace StudentsAffairs.INNOTECH.Repository.Repositories;

public class ProfessorRepository(ApplicationDbContext context)
    : GenericRepository<Professor>(context), IProfessorRepository
{
    public async Task<bool> IsProfessorExist(Professor professor)
        => await ExistsAsync(p =>
                p.NormalizedFullName!.Equals(professor.NormalizedFullName) ||
                p.Mobile!.Equals(professor.Mobile));
}
