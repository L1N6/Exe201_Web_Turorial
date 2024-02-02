using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web.Controllers
{
    public class TutorJobController : Controller
    {
        public IActionResult AfterRegister()
        {
            return View();
        }
    }
}
