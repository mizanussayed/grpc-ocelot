using Demo.Exam.Entities;

namespace Demo.Exam.Data
{
    public interface IExamSetupRepository
    {
        Task<List<ExamSetup>> GetAllAsync();
        Task<ExamSetup?> GetAsync(int Id);
        Task CreateAsync(ExamSetup examSetup);
        Task UpdateAsync(ExamSetup examSetup);
        Task DeleteAsync(int Id);
    }
}
