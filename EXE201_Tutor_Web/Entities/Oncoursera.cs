using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Oncoursera
    {
        public Oncoursera()
        {
            Oncoursedetails = new HashSet<Oncoursedetail>();
        }

        public int OnCourseId { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
        public int? StudentId { get; set; }
        public int? CourseraId { get; set; }

        public virtual Coursera? Coursera { get; set; }
        public virtual Student? Student { get; set; }
        public virtual ICollection<Oncoursedetail> Oncoursedetails { get; set; }
    }
}
