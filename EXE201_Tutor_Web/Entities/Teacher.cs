using System.ComponentModel.DataAnnotations;

namespace EXE201_Tutor_Web.Entities
{
    public class Teacher
    {
        [Key]

        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<Coursera>? Courseras { get; set; }
    }
}
