using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web_API.Entites
{
    public class OnMoocDetail
    {
        [Key]
        public int OnMoocDetailId { get; set; }
        public int? Score { get; set; }
        public string? Answer { get; set; }
        public string? Status { get; set; }

        [ForeignKey("MoocDetail")]
        public int? MoocDetailId { get; set; }
        public virtual MoocDetail? MoocDetail { get; set; }

        [ForeignKey("OnMooc")]
        public int? OnMoocId { get; set; }

        public virtual OnMooc? OnMooc { get; set; }

    }
}
