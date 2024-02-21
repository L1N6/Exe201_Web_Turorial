using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web.Entites
{
    public class OnCoursera
    {
        [Key]
        public int OnCourseId { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public virtual Student? Student { get; set; }

        [ForeignKey("Coursera")]
        public int? CourseraId { get; set; }
        public virtual Coursera? Coursera { get; set; }

        // Navigation properties for related entities
        public virtual ICollection<OnCourseraDetail>? OnCourseDetails { get; set; }

    }
}
