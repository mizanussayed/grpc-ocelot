namespace Demo.Exam.ViewModels
{
    public class ExamSetupRequest
    {
        public DateTime ExamDate { get; set; }
        public int Duration { get; set; }
        public int CourseId { get; set; }
        public string? CenterName { get; set; }
    }
}
