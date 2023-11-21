using Demo.Academic.Entities;

namespace Demo.Academic.Data
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetAsync(int Id);
        Task CreateAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int Id);
    }
}
