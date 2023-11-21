using Demo.Exam.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Exam.Data
{
    public class MarkEntryRepository(AppDbContext Context) : IMarkEntryRepository
    {

        public async Task CreateRangeAsync(List<MarkEntry> mark)
        {
            await Context.MarkEntries.AddRangeAsync(mark);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletedMarkEntry = await Context.MarkEntries.FindAsync(id);
            if (deletedMarkEntry is not null)
            {
                Context.MarkEntries.Remove(deletedMarkEntry);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<MarkEntry>> GetAllAsync()
        {
            return await Context.MarkEntries.ToListAsync();
        }

        public async Task<MarkEntry?> GetAsync(int Id)
        {
            var markEntry = await Context.MarkEntries.AsNoTracking().FirstOrDefaultAsync(f => f.Id == Id);
            if (markEntry is not null)
            {
                return markEntry;
            }
            return null;
        }

        public async Task UpdateRangeAsync(List<MarkEntry> markEntry)
        {
            Context.MarkEntries.UpdateRange(markEntry);
            await Context.SaveChangesAsync();
        }
    }
}
