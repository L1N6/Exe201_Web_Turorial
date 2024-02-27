using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            Courseras = new HashSet<Coursera>();
        }

        public int TeacherId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Avatar { get; set; } = null!;

        public virtual ICollection<Coursera> Courseras { get; set; }
    }
}
