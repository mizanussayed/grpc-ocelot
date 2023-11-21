using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Academic.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual List<Department> Department { get; set; } = [];
    }
}
