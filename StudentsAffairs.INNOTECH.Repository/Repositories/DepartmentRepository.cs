namespace StudentsAffairs.INNOTECH.Repository.Repositories;

public class DepartmentRepository(ApplicationDbContext context)
    : GenericRepository<Department>(context), IDepartmentRepository
{
    public async Task<bool> IsDepartmentExist(Department department)
        => await ExistsAsync(d =>
        d.NormalizedName!.Equals(department.NormalizedName) ||
        d.Id.Equals(department.Id));

    public async Task<bool> IsDepartmentWithIdExist(int departmentId)
        => await ExistsAsync(d => d.Id.Equals(departmentId));
}
