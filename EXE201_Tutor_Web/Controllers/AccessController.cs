
using EXE201_Tutor_Web.Entities;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

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
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img", "student");
                    // Ensure the uploads folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Combine the uploads folder path with the unique file name
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Copy the uploaded file to the specified file path
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await avatarFile.CopyToAsync(fileStream);
                    }
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
            HttpContext.Session.SetString("LogedIn", student.StudentId + "");
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
            Student studentCheck = _context.Students.FirstOrDefault(s => s.Email.Equals(email));
            if (studentCheck == null)
            {
                TempData["ErrorFPwdMessage"] = "Email này chưa được đăng kí. Vui lòng kiểm tra lại!";
            }

            string newRandomPassword = GenerateRandomString(5);
            return View();
        }
        public string GenerateRandomString(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult ChangePasswordProcess(int id, string newRandomPassword, string newPassword)
        {
            return View();
        }

        public IActionResult RegisterWithGoogle(string returnUrl = "/")
        {
            var redirectUrl = Url.Action("RegisterWithGoogleCallback", "Access", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> RegisterWithGoogleCallback(string returnUrl = "/")
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                // Xử lý xác thực không thành công ở đây
                return RedirectToAction("SignUp", "Access");
            }

            var email = authenticateResult.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var name = authenticateResult.Principal.FindFirst(ClaimTypes.Name)?.Value;
            var newUser = new Student { Email = email, Name = name, UserName = "string", Password = "string", Address = "string", Avatar = "string" };
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://localhost:7184/api/Login/{email}");

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("SignIn", "Access");
                    }
                    else
                    {
                        // Email chưa tồn tại, tạo tài khoản mới và lưu vào cơ sở dữ liệu


                        try
                        {

                            using (HttpResponseMessage res = await client.PostAsJsonAsync("https://localhost:7184/api/Login/register", newUser))
                            {
                                if (res.IsSuccessStatusCode)
                                {

                                    return RedirectToAction("SignIn", "Access");
                                }
                                else
                                {
                                    TempData["ErrorMessage"] = "Failed to create author. Please try again later.";
                                    // Trả về view với tên cụ thể
                                    return View("Error");
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            TempData["ErrorMessage"] = $"Error creating author: {ex.Message}";
                            // Trả về view với tên cụ thể
                            return View("Error");
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }

            // Xử lý lỗi nếu có
            return RedirectToAction("Error");
        }
    }
}
