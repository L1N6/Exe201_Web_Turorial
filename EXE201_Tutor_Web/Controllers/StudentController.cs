
using EXE201_Tutor_Web.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXE201_Tutor_Web.Controllers
{
    public class StudentController : Controller
    {
        public readonly EXE_DataBaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public StudentController(EXE_DataBaseContext context, IWebHostEnvironment hostingEnvironment)
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
