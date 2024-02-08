using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Dto
{
    public class UserDTO: User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
    }
}
