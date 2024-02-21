using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web.Entites
{
    public class MoocDetail
    {
        [Key] // Primary Key

        public int MoocDetailId { get; set; }

        [ForeignKey("Mooc")]
        public int MoocId { get; set; } // Foreign key to Mooc

        // Navigation property for related Mooc
        public virtual Mooc? Mooc { get; set; }

        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Content { get; set; }
        public int? TypeId { get; set; }
        public string? Answer { get; set; }
        public int? Score { get; set; }
        public virtual ICollection<OnMoocDetail>? OnMoocDetails { get; set; }

    }
}
