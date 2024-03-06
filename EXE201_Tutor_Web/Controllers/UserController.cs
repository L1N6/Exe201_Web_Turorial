using EXE201_Tutor_Web.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EXE201_Tutor_Web.Controllers
{
    public class UserController : Controller
    {
        string link = "http://localhost:5052/api/User";

        public IActionResult Index() { return View(); }

        private readonly HttpClient _httpClient;
        private readonly EXE_DataBaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UserController(IHttpClientFactory httpClientFactory, EXE_DataBaseContext context, IWebHostEnvironment hostingEnvironment)
        {
            _httpClient = httpClientFactory.CreateClient();
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult ExternalLogin(string provider, string returnUrl = "/")
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "User", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "/")
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                // Handle authentication failure
                return RedirectToAction("ExternalLogin");
            }

            var email = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email);
            var name = authenticateResult.Principal.FindFirstValue(ClaimTypes.Name);


            // Tạo đối tượng Student với thông tin ảnh đại diện
            var newStudent = new Student
            {
                Name = name,
                Email = email,
                UserName = name,
                Avatar = "string",
                Password = "string"
            };

            // Thêm Student mới vào cơ sở dữ liệu
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("AccountValid", newStudent.Email);

            return RedirectToAction("Index", "Home");

        }   


        public async Task<IActionResult> Logout()
        {
            // Đăng xuất người dùng
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Chuyển hướng người dùng về trang chủ hoặc trang đăng nhập (tùy ý của bạn)
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Profile()
        {
            TempData["LayoutType"] = "Layout_2";
            var loggedInUserEmail = HttpContext.Session.GetString("AccountValid");
            if (!string.IsNullOrEmpty(loggedInUserEmail))
            {
                // Truy vấn thông tin người dùng từ cơ sở dữ liệu
                var user = await _context.Students
                    .Include(s => s.OnCoursera)
                    .FirstOrDefaultAsync(s => s.Email == loggedInUserEmail);
                if (user != null)
                {
                    List<OnCoursera> onCourseras = _context.OnCoursera
                        .Include(on => on.Coursera)
                        .Where(oc => oc.StudentId == user.StudentId)
                        .ToList();
                    TempData["ListOnCoursera"] = onCourseras;
                    return View("Profile", user);
                }
                else
                {
                    // Không tìm thấy thông tin người dùng trong cơ sở dữ liệu
                    TempData["ErrorMessage"] = "Không tìm thấy thông tin người dùng.";
                    return RedirectToAction("SignIn", "Access");
                }
            }
            else
            {
                // Session không chứa email hợp lệ
                TempData["ErrorMessage"] = "Không tìm thấy thông tin người dùng.";
                return RedirectToAction("SignIn", "Access");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromBody] Student updatedStudent)
        {
            try
            {
                // Kiểm tra xem thông tin người dùng đã được gửi lên không
                if (updatedStudent == null)
                {
                    return BadRequest("Dữ liệu không hợp lệ.");
                }

                // Lấy thông tin người dùng từ cơ sở dữ liệu
                var loggedInUserEmail = HttpContext.Session.GetString("AccountValid");
                var user = await _context.Students.FirstOrDefaultAsync(s => s.Email == loggedInUserEmail);

                if (user == null)
                {
                    return NotFound("Không tìm thấy người dùng.");
                }

                // Cập nhật thông tin người dùng từ dữ liệu được gửi lên
                user.Name = updatedStudent.Name;
                user.Email = updatedStudent.Email;
                user.Address = updatedStudent.Address;

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.Students.Update(user);
                await _context.SaveChangesAsync();

                return Ok("Cập nhật thông tin người dùng thành công.");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(500, $"Đã xảy ra lỗi: {ex.Message}");
            }
        }
    }
}
