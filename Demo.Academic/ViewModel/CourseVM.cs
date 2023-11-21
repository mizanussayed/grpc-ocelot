namespace Demo.Academic.ViewModel
{
    public class CourseVM
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        public decimal Credit { get; set; } 
        public int DepartmentId { get; set; } 
    }
}
