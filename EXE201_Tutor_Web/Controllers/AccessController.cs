using EXE201_Tutor_Web.Database;
using EXE201_Tutor_Web.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXE201_Tutor_Web.Controllers
{
    public class AccessController : Controller
    {

        public readonly EXE_DataBaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AccessController(EXE_DataBaseContext context, IWebHostEnvironment hostingEnvironment)
        {
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

        [HttpPost]
        public async Task<IActionResult> SignUpProcess(Student student, IFormFile avatarFile)
        {

            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.Email.Equals(student.Email));
            if (existingStudent != null)
            {
                // Email already exists, set error message in TempData and redirect back to registration page
                TempData["ErrorMessage"] = "Email already exists.";
                return RedirectToAction("SignUp");
            }
            else
            {

                // Save the filename to the student object
                if (avatarFile != null)
                {
                    // Generate a unique filename for the avatar
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + avatarFile.FileName;
                    student.Avatar = uniqueFileName;
                }

                // Save the student details to the database
                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                // Redirect to a success page or perform any other action
                return RedirectToAction("SignUpProcess");

            }

            // If the model state is not valid, return to the registration page with validation errors
        }


        [HttpPost]
        public async Task<IActionResult> UploadAvatar(IFormFile avatarFile)
        {
            try
            {
                // Check if the avatar file is not null and is valid
                if (avatarFile != null && avatarFile.Length > 0)
                {
                    // Define the uploads folder path
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img", "student");

                    // Ensure the uploads folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Generate a unique file name for the avatar
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + avatarFile.FileName;

                    // Combine the uploads folder path with the unique file name
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Copy the uploaded file to the specified file path
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await avatarFile.CopyToAsync(fileStream);
                    }

                    // Return the URL of the uploaded avatar
                    string imageUrl = Url.Content(Path.Combine("~/img/student", uniqueFileName));
                    return Ok(imageUrl);
                }
                else
                {
                    // If no file is uploaded, return a bad request status
                    return BadRequest("No file uploaded.");
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs during the upload process, return a server error status
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AccountValid");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignInProcess(string email, string password)
        {
            Student student = _context.Students.Where(s => s.Email.Contains(email) && s.Password.Contains(password)).FirstOrDefault();
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
