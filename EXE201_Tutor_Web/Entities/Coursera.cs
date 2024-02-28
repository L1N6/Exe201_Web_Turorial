using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web.Entities
{
    public class Coursera
    {
        [Key]

        public int CourseraId { get; set; }
        public string? Name { get; set; }
        public string? CodeName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TotalDate { get; set; }
        public double Money { get; set; }
        public string? Description { get; set; }
        public string? Major { get; set; }
        public string? HashTag { get; set; }
        public string? Image { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<OnCoursera>? OnCoursera { get; set; }
        public virtual ICollection<CourseraDetail>? CourseraDetails { get; set; }
    }
}
