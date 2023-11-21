using Demo.Academic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Academic.Data
{
    public class CourseRepository(AppDbContext Context) : ICourseRepository
    {

        public async Task CreateAsync(Course course)
        {
            await Context.Courses.AddAsync(course);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletedCourse = await Context.Courses.FindAsync(id);
            if (deletedCourse is not null)
            {
                Context.Courses.Remove(deletedCourse);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await Context.Courses.ToListAsync();
        }

        public async Task<Course?> GetAsync(int Id)
        {
            var course = await Context.Courses.AsNoTracking().FirstOrDefaultAsync(f => f.Id == Id);
            if (course is not null)
            {
                return course;
            }
            return null;
        }

        public async Task UpdateAsync(Course course)
        {
            Context.Courses.Update(course);
            await Context.SaveChangesAsync();
        }
    }
}
