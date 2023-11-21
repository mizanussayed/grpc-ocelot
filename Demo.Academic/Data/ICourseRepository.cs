using Demo.Academic.Entities;

namespace Demo.Academic.Data
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetAsync(int Id);
        Task CreateAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(int Id);
    }
}
