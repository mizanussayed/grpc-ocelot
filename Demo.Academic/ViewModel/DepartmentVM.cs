
namespace Demo.Academic.ViewModel
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        public int FacultyId { get; set; }
    }
}
