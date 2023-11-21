using Demo.Academic.Entities;

namespace Demo.Academic.Data
{
    public interface IFacultyRepository
    {
        Task<List<Faculty>> GetAllAsync();
        Task<Faculty?> GetAsync(int Id);
        Task CreateAsync(Faculty faculty);
        Task UpdateAsync(Faculty faculty);
        Task DeleteAsync(int Id);
    }
}
