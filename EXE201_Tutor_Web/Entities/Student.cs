    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

namespace EXE201_Tutor_Web.Entities
{
    public class Student
    {
        [Key]

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public virtual ICollection<OnCoursera>? OnCoursera { get; set; }
        public virtual ICollection<OrderCoursera>? OrderCoursera { get; set; }
        public virtual ICollection<Feedback>? Feedback { get; set; }
    }

    public class StudentFilterDto
    {
        public string SearchText { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        // Add other filtering properties as needed
    }

    public class StudentViewModel
    {
        public List<Student> Students { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
    }
}
