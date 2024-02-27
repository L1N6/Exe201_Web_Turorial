using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web.Entities
{
    public class Mooc
    {
        [Key] // Primary Key

        public int MoocId { get; set; }

        [ForeignKey("CourseraDetail")]
        public int CourseraDetailId { get; set; } // Foreign key to CourseraDetail

        // Navigation property for related CourseraDetail
        public virtual CourseraDetail? CourseraDetail { get; set; }

        public string? Name { get; set; }
        public string? CodeName { get; set; }
        public DateTime? Date { get; set; }
        public int? MinScore { get; set; }

        // Navigation property for related MoocDetails
        public virtual ICollection<MoocDetail>? MoocDetails { get; set; }
        public virtual ICollection<OnMooc>? OnMoocs { get; set; }


    }
}
