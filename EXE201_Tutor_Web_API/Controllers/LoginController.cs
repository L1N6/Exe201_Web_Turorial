﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using EXE201_Tutor_Web_API.Database;
using Microsoft.EntityFrameworkCore;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Services.StudentService;

namespace EXE201_Tutor_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly Exe201_Tutor_Context _context;
        public LoginController(IMapper mapper, Exe201_Tutor_Context context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok("Welcome to login page");
        }

        [HttpGet]
        [Route("google-login")]
        public IActionResult GoogleLogin(string returnUrl = "/")
        {
            var redirectUrl = Url.Action(nameof(GoogleResponse), "Login", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, "Google");
        }

        [HttpGet]
        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
        {
            var authenticateResult = await HttpContext.AuthenticateAsync("Google");

            if (!authenticateResult.Succeeded)
            {
                // Xử lý thất bại trong xác thực
                return BadRequest("Authentication failed");
            }
            Student student = new Student()
            {
                Email = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email),
                Name = authenticateResult.Principal.FindFirstValue(ClaimTypes.Name),                           
            };

            // Trích xuất thông tin người dùng
            
            return Ok(student); // Trả về một kết quả thành công
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            // Đăng xuất người dùng
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Chuyển hướng người dùng về trang chủ hoặc trang đăng nhập (tùy ý của bạn)
            return Ok("Logged out successfully");
        }

        [HttpGet("{email}")]
        public IActionResult CheckExistence(string email)
        {
            // Kiểm tra xem email có tồn tại trong bảng Student hay Teacher không
            var student = _context.Student.FirstOrDefault(s => s.Email == email);
            var teacher = _context.Teacher.FirstOrDefault(t => t.Email == email);

            if (student != null)
            {
                return Ok(email);
            }
            else if (teacher != null)
            {
                return Ok(email);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            try
            {

                Student stu = new Student()
                {
                    Name = student.Name,
                    UserName = student.UserName,
                    Email = student.Email,
                    Password = student.Password,
                    Address = student.Address,
                    Avatar = student.Avatar,
                    OnCourseras = new List<OnCoursera>()
                };
                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();
                return Ok(_context.Student.ToList()); // Trả về mã 200 OK nếu thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
