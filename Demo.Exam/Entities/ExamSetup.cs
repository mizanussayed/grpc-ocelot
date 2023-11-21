namespace Demo.Exam.Entities
{
    public class ExamSetup
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int Duration { get; set; }
        public int CourseId { get; set; }
        public string? CenterName { get; set; }
    }
}
