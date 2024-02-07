using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignUpProcess()
        {
            return View("SignUpSuccess");
        } 
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
