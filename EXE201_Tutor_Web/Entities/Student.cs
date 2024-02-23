using System;
using System.Collections.Generic;

namespace EXE201_Tutor_Web.Entities
{
    public partial class Student
    {
        public Student()
        {
            Oncourseras = new HashSet<Oncoursera>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Address { get; set; }
        public string? Avatar { get; set; }

        public virtual ICollection<Oncoursera> Oncourseras { get; set; }
    }
}
