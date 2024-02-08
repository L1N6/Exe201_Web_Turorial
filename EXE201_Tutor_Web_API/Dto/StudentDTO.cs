using EXE201_Tutor_Web_API.Entites;
using System.ComponentModel.DataAnnotations;

namespace EXE201_Tutor_Web_API.Dto
{
    public class StudentDTO : Student
    {

       public List<string> CourseraNam { get; set; }

    }
}
