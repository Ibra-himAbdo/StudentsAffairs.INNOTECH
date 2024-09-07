namespace StudentsAffairs.INNOTECH.Core.Repositories.Contract;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    Task<bool> IsDepartmentExist(Department department);
    Task<bool> IsDepartmentWithIdExist(int departmentId);
}
