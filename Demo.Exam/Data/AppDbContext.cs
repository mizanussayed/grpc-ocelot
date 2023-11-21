using Demo.Exam.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Exam.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<MarkEntry> MarkEntries { get; set; }
        public DbSet<ExamSetup> ExamSetups { get; set; }
    }
}
