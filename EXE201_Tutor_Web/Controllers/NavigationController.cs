using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web.Controllers
{
    public class NavigationController : Controller
    {
        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Job()
        {
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }
    }
}
