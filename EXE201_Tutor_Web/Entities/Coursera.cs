using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Coursera
    {
        public Coursera()
        {
            Courseradetails = new HashSet<Courseradetail>();
            Oncourseras = new HashSet<Oncoursera>();
        }

        public int CourseraId { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Description { get; set; }
        public int? TeacherId { get; set; }
        public DateTime? EndDate { get; set; }
        public string? HashTag { get; set; }
        public string? Image { get; set; }
        public string? Major { get; set; }
        public int TotalDate { get; set; }
        public string? CodeName { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Courseradetail> Courseradetails { get; set; }
        public virtual ICollection<Oncoursera> Oncourseras { get; set; }
    }
}
