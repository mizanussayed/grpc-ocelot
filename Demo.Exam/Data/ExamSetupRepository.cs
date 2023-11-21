using Demo.Exam.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Exam.Data
{
    public class ExamSetupRepository(AppDbContext Context) : IExamSetupRepository
    {

        public async Task CreateAsync(ExamSetup course)
        {
            await Context.ExamSetups.AddAsync(course);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletedExamSetup = await Context.ExamSetups.FindAsync(id);
            if (deletedExamSetup is not null)
            {
                Context.ExamSetups.Remove(deletedExamSetup);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<ExamSetup>> GetAllAsync()
        {
            return await Context.ExamSetups.ToListAsync();
        }

        public async Task<ExamSetup?> GetAsync(int Id)
        {
            var examSetup = await Context.ExamSetups.AsNoTracking().FirstOrDefaultAsync(f => f.Id == Id);
            if (examSetup is not null)
            {
                return examSetup;
            }
            return null;
        }

        public async Task UpdateAsync(ExamSetup course)
        {
            Context.ExamSetups.Update(course);
            await Context.SaveChangesAsync();
        }
    }
}
