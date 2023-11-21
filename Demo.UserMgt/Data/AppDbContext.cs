using Demo.UserMgt.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.UserMgt.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<StudentInfo> StudentInfos { get; set; }
    }
}
