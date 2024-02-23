using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Courseradetail
    {
        public Courseradetail()
        {
            Moocs = new HashSet<Mooc>();
            Oncoursedetails = new HashSet<Oncoursedetail>();
        }

        public int CourseraDetailId { get; set; }
        public int CourseraId { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? CodeName { get; set; }

        public virtual Coursera Coursera { get; set; } = null!;
        public virtual ICollection<Mooc> Moocs { get; set; }
        public virtual ICollection<Oncoursedetail> Oncoursedetails { get; set; }
    }
}
