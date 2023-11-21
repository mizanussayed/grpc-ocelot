using Demo.Academic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Academic.Data
{
    public class FacultyRepository(AppDbContext Context) : IFacultyRepository
    {

        public async Task CreateAsync(Faculty faculty)
        {
            await Context.Faculties.AddAsync(faculty);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletedFaculty = await Context.Faculties.FindAsync(id);
            if (deletedFaculty is not null)
            {
                Context.Faculties.Remove(deletedFaculty);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<Faculty>> GetAllAsync()
        {
            return await Context.Faculties.ToListAsync();
        }

        public async Task<Faculty?> GetAsync(int Id)
        {
            var faculty = await Context.Faculties.AsNoTracking().FirstOrDefaultAsync(f => f.Id == Id);
            if (faculty is not null)
            {
                return faculty;
            }
            return null;
        }

        public async Task UpdateAsync(Faculty faculty)
        {
            Context.Faculties.Update(faculty);
            await Context.SaveChangesAsync();
        }
    }
}
