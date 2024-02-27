using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Mooc
    {
        public Mooc()
        {
            Moocdetails = new HashSet<Moocdetail>();
            Onmoocs = new HashSet<Onmooc>();
        }

        public int MoocId { get; set; }
        public int CourseraDetailId { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public int? MinScore { get; set; }
        public string? CodeName { get; set; }

        public virtual Courseradetail CourseraDetail { get; set; } = null!;
        public virtual ICollection<Moocdetail> Moocdetails { get; set; }
        public virtual ICollection<Onmooc> Onmoocs { get; set; }
    }
}
