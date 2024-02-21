using EXE201_Tutor_Web.Database;
using EXE201_Tutor_Web.Entites;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web.Controllers
{
    public class StudentController : Controller
    {
        public readonly Exe201_Tutor_Context _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public StudentController(Exe201_Tutor_Context context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        

        public IActionResult SignUpSuccess()
        {
            // You can return a view confirming successful registration
            return View();
        }
    }
}
