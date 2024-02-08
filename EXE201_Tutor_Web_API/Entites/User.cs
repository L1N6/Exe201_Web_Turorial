namespace EXE201_Tutor_Web_API.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
    }
}
