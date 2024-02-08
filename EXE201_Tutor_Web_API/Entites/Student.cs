using System.ComponentModel.DataAnnotations;

namespace EXE201_Tutor_Web_API.Entites
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
