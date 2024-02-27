using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Onmooc
    {
        public Onmooc()
        {
            Onmoocdetails = new HashSet<Onmoocdetail>();
        }

        public int OnMoocId { get; set; }
        public int? TotalScore { get; set; }
        public DateTime? DateSuccess { get; set; }
        public string? Status { get; set; }
        public int? MoocId { get; set; }
        public int? OnCourseDetailId { get; set; }

        public virtual Mooc? Mooc { get; set; }
        public virtual Oncoursedetail? OnCourseDetail { get; set; }
        public virtual ICollection<Onmoocdetail> Onmoocdetails { get; set; }
    }
}
