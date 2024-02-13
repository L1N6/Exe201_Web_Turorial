using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web_API.Entites
{
    public class OnCourse
    {
        [Key]
        public int OnCourseId { get; set; }

        
        
        public DateTime? Date { get; set; }
        public string? Status { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey("Coursera")]
        public int? CourseraId { get; set; }
        public virtual Coursera? Coursera { get; set; }

        // Navigation properties for related entities
        public virtual ICollection<OnCourseDetail>? OnCourseDetails { get; set; }

    }
}
