using Demo.Academic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Academic.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
