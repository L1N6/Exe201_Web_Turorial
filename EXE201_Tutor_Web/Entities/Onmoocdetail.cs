using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Onmoocdetail
    {
        public int OnMoocDetailId { get; set; }
        public int? Score { get; set; }
        public string? Answer { get; set; }
        public string? Status { get; set; }
        public int? MoocDetailId { get; set; }
        public int? OnMoocId { get; set; }

        public virtual Moocdetail? MoocDetail { get; set; }
        public virtual Onmooc? OnMooc { get; set; }
    }
}
