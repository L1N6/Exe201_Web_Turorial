using EXE201_Tutor_Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXE201_Tutor_Web.Controllers
{
    public class AdminController : Controller
    {
        public readonly EXE_DataBaseContext _context;
        public AdminController(EXE_DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Student(StudentFilterDto filter)
        {
            var query = _context.Students.Include(x => x.OnCoursera).AsQueryable();

            // Apply filtering
            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                query = query.Where(s => s.Name.Contains(filter.SearchText) || s.Email.Contains(filter.SearchText));
            }

            // Paging
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize; // default page size
            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);
            var students = query.Skip((filter.Page - 1) * filter.PageSize)
                                .Take(filter.PageSize)
                                .ToList();

            var viewModel = new StudentViewModel
            {
                Students = students,
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = filter.Page,
                PageSize = filter.PageSize,
                SearchText = filter.SearchText
            };

            return View(viewModel);
        }

        public IActionResult StudentDetail(int id)
        {

            var student = _context.Students.Where(x => x.StudentId == id).Include(x => x.OnCoursera).ThenInclude(x => x.Coursera).FirstOrDefault();

            if (student == null)
            {
                return NotFound(); // Return a 404 Not Found response if the student is not found
            }

            return View(student);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {

            if (email == "admin" &&  password == "123")
            {
                return RedirectToAction("Student", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Fail";
                return View();
            }
        }
    }
}
