using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            TempData["LayoutType"] = "Layout_2";
            return View();
        }
    }
}
