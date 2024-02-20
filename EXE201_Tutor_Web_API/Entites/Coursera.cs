using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web_API.Entites
{
    public class Coursera
    {
        [Key]
        public int CourseraId { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<OnCoursera>? OnCourses { get; set; }
        public virtual ICollection<CourseraDetail>? CourseraDetails { get; set; }
    }
}
