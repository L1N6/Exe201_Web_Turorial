using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using EXE201_Tutor_Web_API.Entites;

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
