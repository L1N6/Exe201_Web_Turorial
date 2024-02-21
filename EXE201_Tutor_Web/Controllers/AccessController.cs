using EXE201_Tutor_Web.Database;
using EXE201_Tutor_Web.Entites;
using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web.Controllers
{
    public class AccessController : Controller
    {
        public readonly Exe201_Tutor_Context _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AccessController(Exe201_Tutor_Context context, IWebHostEnvironment hostingEnvironment) { 
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AccountValid");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SignInProcess(string email, string password)
        {
            Student student = _context.Student.Where(s => s.Email.Contains(email) && s.Password.Contains(password)).FirstOrDefault();
            if (student == null)
            {
                TempData["InvalidAccountMessage"] = "Tài khoản không hợp lệ";
                return RedirectToAction("SignIn");
            }
            HttpContext.Session.SetString("AccountValid", student.Email);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUpProcess()
        {
            return View("SignUpSuccess");
        } 
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult ForgotPasswordProcess(string email)
        {
            return View();
        }
    }
}
