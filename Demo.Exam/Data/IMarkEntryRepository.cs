using Demo.Exam.Entities;

namespace Demo.Exam.Data
{
    public interface IMarkEntryRepository
    {
        Task<List<MarkEntry>> GetAllAsync();
        Task<MarkEntry?> GetAsync(int Id);
        Task CreateRangeAsync(List<MarkEntry> examSetup);
        Task UpdateRangeAsync(List<MarkEntry> examSetup);
        Task DeleteAsync(int Id);
    }
}
