using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Oncoursedetail
    {
        public Oncoursedetail()
        {
            Onmoocs = new HashSet<Onmooc>();
        }

        public int OnCourseDetailId { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
        public int? CourseraDetailId { get; set; }
        public int? OnCourseId { get; set; }

        public virtual Courseradetail? CourseraDetail { get; set; }
        public virtual Oncoursera? OnCourse { get; set; }
        public virtual ICollection<Onmooc> Onmoocs { get; set; }
    }
}
