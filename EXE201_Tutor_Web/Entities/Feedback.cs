using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web.Entities
{
    public class Feedback
    {
        public int FeedbackId { get; set; } // Khóa chính tự tăng
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Coursera")]
        public int CourseraId { get; set; }
        public virtual Coursera Coursera { get; set; }
        public string? Review { get; set; }
    }
}
