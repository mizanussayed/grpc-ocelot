using Demo.UserMgt.Entities;

namespace Demo.UserMgt.Data
{
    public interface IStudentInfoRepository
    {
        Task<List<StudentInfo>> GetAllAsync();
        Task<StudentInfo?> GetAsync(int Id);
        Task CreateAsync(StudentInfo examSetup);
        Task UpdateAsync(StudentInfo examSetup);
        Task DeleteAsync(int Id);
    }
}
