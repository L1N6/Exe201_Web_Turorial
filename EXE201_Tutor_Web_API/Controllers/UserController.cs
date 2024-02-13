using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EXE201_Tutor_Web_API.Controllers
{
    {
        {
                x.Issuer,
                x.OriginalIssuer,
                x.Type,
                x.Value
            });

            return RedirectToAction("Index", "Home");
        }
            
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            // Đăng xuất người dùng
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
            // Chuyển hướng người dùng về trang chủ hoặc trang đăng nhập (tùy ý của bạn)
            return RedirectToAction("Index", "Home");
        }
    }
}
