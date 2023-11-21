namespace Demo.Exam.ViewModels
{
    public class ExamSetupVM
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int Duration { get; set; }
        public int CourseId { get; set; }
        public string? CenterName { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int DepartmentId { get; set; }
    }
}
