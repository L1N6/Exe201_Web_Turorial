using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web_API.Entites
{
    public class OnMooc
    {
        [Key]
        public int OnMoocId { get; set; }
        public int? TotalScore { get; set; }
        public DateTime? DateSuccess { get; set; }
        public string? Status { get; set; }

        [ForeignKey("Mooc")]
        public int? MoocId { get; set; }
        public virtual Mooc? Mooc { get; set; }

        [ForeignKey("OnCourseDetail")]
        public int? OnCourseDetailId { get; set; }
        public virtual OnCourseraDetail? OnCourseDetail { get; set; }

        // Add navigation properties for related entities
        public virtual ICollection<OnMoocDetail>? OnMoocDetails { get; set; }

    }
}
