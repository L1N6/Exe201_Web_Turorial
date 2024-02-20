using EXE201_Tutor_Web.Models;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Claims;

namespace EXE201_Tutor_Web.Controllers
{
    public class UserController : Controller
    {
        string link = "http://localhost:5052/api/User";
        public IActionResult Profile()
        {
            TempData["LayoutType"] = "Layout_2";
            return View();
        }

        public IActionResult Index() { return View(); }

        private readonly HttpClient _httpClient;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
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

            // Extract user information
            var email = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email);
            var name = authenticateResult.Principal.FindFirstValue(ClaimTypes.Name);
            //Kiem tra co ton tai duoi database khong
            //Co thi cho login
            //Khong thi chuyen sang sign up
            // Your logic to handle the user data
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://localhost:7184/api/Login/{email}");

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        return RedirectToAction("SignUp", "Access");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            // Đăng xuất người dùng
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Chuyển hướng người dùng về trang chủ hoặc trang đăng nhập (tùy ý của bạn)
            return RedirectToAction("Index", "Home");
        }

    }
}
