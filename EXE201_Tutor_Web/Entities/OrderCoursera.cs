using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201_Tutor_Web.Entities
{
    public class OrderCoursera
    {
        [Key]
        public int OrderCourseraId { get; set; }
        public double Money { get; set; }
        public bool? Status { get; set; }
        public DateTime? DateAccepted { get; set; }
        public string? BankDescription { get; set; }
        public string? BankNumber { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Coursera")]
        public int CourseraId { get; set; }
        public virtual Coursera Coursera { get; set; }

    }

    public class OrderCourseraFilterDto
    {
        public string SearchText { get; set; }
        public int Page { get; set; }
        public string Status { get; set; } // Add this property

        public int PageSize { get; set; }
        // Add other filtering properties as needed
    }

    public class OrderCourseraViewModel
    {
        public List<OrderCoursera> OrderCourseras { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
    }
}
