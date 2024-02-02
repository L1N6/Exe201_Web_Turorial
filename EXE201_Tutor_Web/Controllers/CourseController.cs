using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Choice()
        {
            return View();
        }

        public IActionResult OnlineTutorRegister()
        {
            return View();
        }
    }
}
