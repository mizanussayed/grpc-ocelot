using Demo.UserMgt.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.UserMgt.Data
{
    public class StudentInfoRepository(AppDbContext Context) : IStudentInfoRepository
    {

        public async Task CreateAsync(StudentInfo studentInfo)
        {
            await Context.StudentInfos.AddAsync(studentInfo);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletedStudentInfo = await Context.StudentInfos.FindAsync(id);
            if (deletedStudentInfo is not null)
            {
                Context.StudentInfos.Remove(deletedStudentInfo);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<StudentInfo>> GetAllAsync()
        {
            return await Context.StudentInfos.ToListAsync();
        }

        public async Task<StudentInfo?> GetAsync(int Id)
        {
            var studentInfo = await Context.StudentInfos.AsNoTracking().FirstOrDefaultAsync(f => f.Id == Id);
            if (studentInfo is not null)
            {
                return studentInfo;
            }
            return null;
        }

        public async Task UpdateAsync(StudentInfo studentInfo)
        {
            Context.StudentInfos.Update(studentInfo);
            await Context.SaveChangesAsync();
        }
    }
}
