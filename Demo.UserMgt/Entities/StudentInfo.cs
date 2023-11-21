namespace Demo.UserMgt.Entities
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required int MobileNumber { get; set; }
        public int DepartmentId { get; set; }
    }
}
