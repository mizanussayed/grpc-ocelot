using System.ComponentModel.DataAnnotations;

namespace Demo.Exam.Entities
{
    public class MarkEntry
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int PassMark {  get; set; }
        public int StudentId { get; set; }
        public int ObtainMark { get; set; }
    }
}
