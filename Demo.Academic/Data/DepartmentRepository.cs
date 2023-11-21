using Demo.Academic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Academic.Data
{
    public class DepartmentRepository(AppDbContext Context) : IDepartmentRepository
    {

        public async Task CreateAsync(Department department)
        {
            await Context.Departments.AddAsync(department);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletedDepartment = await Context.Departments.FindAsync(id);
            if (deletedDepartment is not null)
            {
                Context.Departments.Remove(deletedDepartment);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await Context.Departments.ToListAsync();
        }

        public async Task<Department?> GetAsync(int Id)
        {
            var department = await Context.Departments.AsNoTracking().FirstOrDefaultAsync(f => f.Id == Id);
            if (department is not null)
            {
                return department;
            }
            return null;
        }

        public async Task UpdateAsync(Department department)
        {
            Context.Departments.Update(department);
            await Context.SaveChangesAsync();
        }
    }
}
