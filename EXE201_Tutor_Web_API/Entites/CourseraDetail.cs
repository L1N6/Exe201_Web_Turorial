using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web_API.Entites
{
    public class CourseraDetail
    {
        [Key] // Primary Key

        public int CourseraDetailId { get; set; }

        [ForeignKey("Coursera")] // Foreign Key
        public int CourseraId { get; set; }

        // Navigation property for related Coursera
        public virtual Coursera? Coursera { get; set; }

        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }

        // Navigation property for related Moocs
        public virtual ICollection<Mooc>? Moocs { get; set; }
        public virtual ICollection<OnCourseraDetail>? OnCourseDetails { get; set; }

    }
}
