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

        public async Task<IActionResult> RegisterWithGoogle(string returnUrl = "/")
        {
            var redirectUrl = Url.Action(nameof(RegisterCallback), "Login", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> RegisterCallback(string returnUrl = "/")
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                // Handle authentication failure
                return RedirectToAction("RegisterWithGoogle");
            }

            var email = authenticateResult.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var name = authenticateResult.Principal.FindFirst(ClaimTypes.Name)?.Value;

            //using (HttpClient client = new HttpClient())
            //{
            //    try
            //    {
            //        HttpResponseMessage response = await client.GetAsync($"https://localhost:7184/api/Login/{email}");

            //        if (response.IsSuccessStatusCode)
            //        {
            //            return RedirectToAction("SignIn", "Access");
            //        }
            //        else
            //        {
            //            // Email chưa tồn tại, tạo tài khoản mới và lưu vào cơ sở dữ liệu
            //            var newUser = new Student { Email = email, Name = name };

            //            // Thêm người dùng mới vào cơ sở dữ liệu
            //            var result = await _userManager.CreateAsync(newUser);
            //            if (result.Succeeded)
            //            {
            //                // Đăng nhập người dùng mới và redirect
            //                await _signInManager.SignInAsync(newUser, isPersistent: false);
            //                return RedirectToAction("Index", "Home");
            //            }
            //        }
            //    }
            //    catch (HttpRequestException e)
            //    {
            //        Console.WriteLine($"Exception: {e.Message}");
            //    }
            //}

            

            // Xử lý lỗi nếu có
            return RedirectToAction("Error");
        }
    }
}
