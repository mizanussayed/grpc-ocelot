using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Academic.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }

        [ForeignKey(nameof(FacultyId))]
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public virtual List<Course> Courses { get; set; } = [];
    }
}
