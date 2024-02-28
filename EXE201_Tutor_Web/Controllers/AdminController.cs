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

        public IActionResult Student()
        {
            List<Student> students = _context.Students.Include(x => x.OnCourseras).ToList();
            return View(students);
        }

        public IActionResult StudentDetail(int id)
        {

            var student = _context.Students.Where(x=>x.StudentId == id).Include(x => x.OnCourseras).ThenInclude(x => x.Coursera).FirstOrDefault();

            if (student == null)
            {
                return NotFound(); // Return a 404 Not Found response if the student is not found
            }

            return View(student);
        }
    }
}
