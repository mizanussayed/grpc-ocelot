namespace Demo.Academic.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        public decimal Credit { get; set; } 
        public int DepartmentId { get; set; } 
        public Department? Department { get; set; }
    }
}
