using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Moocdetail
    {
        public Moocdetail()
        {
            Onmoocdetails = new HashSet<Onmoocdetail>();
        }

        public int MoocDetailId { get; set; }
        public int MoocId { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Content { get; set; }
        public int? TypeId { get; set; }
        public string? Answer { get; set; }
        public int? Score { get; set; }
        public string? CodeName { get; set; }

        public virtual Mooc Mooc { get; set; } = null!;
        public virtual ICollection<Onmoocdetail> Onmoocdetails { get; set; }
    }
}
