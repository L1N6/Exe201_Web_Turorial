using EXE201_Tutor_Web.Entities;
using Microsoft.AspNetCore.Mvc;

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
            List<Student> students = _context.Students.ToList();
            return View(students);
        }
    }
}
