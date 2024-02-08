using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EXE201_Tutor_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to the login API!");
        }

        [HttpPost("ExternalLogin")]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Login");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, provider);
        }

        [HttpGet("ExternalLoginCallback")]
        public async Task<IActionResult> ExternalLoginCallback()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                return BadRequest("Authentication failed.");
            }

            var claims = authenticateResult.Principal.Identities.FirstOrDefault()?.Claims.Select(x => new
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
