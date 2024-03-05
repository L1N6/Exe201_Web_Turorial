using EXE201_Tutor_Web.Entities;
using EXE201_Tutor_Web.Models;
using EXE201_Tutor_Web_API.Services.MailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;

namespace EXE201_Tutor_Web.Controllers
{
    public class AdminController : Controller
    {
        public readonly EXE_DataBaseContext _context;
        private readonly ISendMailService _mailService;
        public AdminController(EXE_DataBaseContext context, ISendMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        public IActionResult Student(StudentFilterDto filter)
        {
            var query = _context.Students.Include(x => x.OnCoursera).AsQueryable();

            // Apply filtering
            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                query = query.Where(s => s.Name.Contains(filter.SearchText) || s.Email.Contains(filter.SearchText));
            }

            // Paging
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize; // default page size
            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);
            var students = query.Skip((filter.Page - 1) * filter.PageSize)
                                .Take(filter.PageSize)
                                .ToList();

            var viewModel = new StudentViewModel
            {
                Students = students,
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = filter.Page,
                PageSize = filter.PageSize,
                SearchText = filter.SearchText
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrderCoursera(OrderCourseraFilterDto filter)
        {
            var query = _context.OrderCourseras
                .Include(x => x.Student)
                .Include(x => x.Coursera)
                .AsQueryable();

            // Apply filtering
            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                query = query.Where(o => o.Student.Name.Contains(filter.SearchText) ||
                                         o.Coursera.Name.Contains(filter.SearchText) ||
                                         o.BankDescription.Contains(filter.SearchText));
            }

            if (!string.IsNullOrEmpty(filter.Status))
            {
                bool status = filter.Status == "Accepted";
                query = query.Where(o => o.Status == status);
            }

            // Paging
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize; // default page size
            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);
            var orders = await query.Skip((filter.Page - 1) * filter.PageSize)
                                     .Take(filter.PageSize)
                                     .ToListAsync();

            var viewModel = new OrderCourseraViewModel
            {
                OrderCourseras = orders,
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = filter.Page,
                PageSize = filter.PageSize,
                SearchText = filter.SearchText
            };

            return View(viewModel);
        }
        public IActionResult AcceptedOrder(int id)
        {
            var coursera = _context.OrderCourseras.Where(x => x.CourseraId == id).Include(x => x.Coursera).FirstOrDefault();
            coursera.Status = true;
            coursera.DateAccepted = DateTime.Now;
            _context.OrderCourseras.Update(coursera);
            _context.SaveChanges();

            MailContent content = new MailContent
            {
                To = coursera.Email,
                Subject = "Order Coursera",
                Body = GenerateEmailBody(coursera.Coursera.Name),

            };
            _mailService.SendMail(content);
            return RedirectToAction("OrderCoursera", "Admin");
        }



        public IActionResult StudentDetail(int id)
        {

            var student = _context.Students.Where(x => x.StudentId == id).Include(x => x.OnCoursera).ThenInclude(x => x.Coursera).FirstOrDefault();

            if (student == null)
            {
                return NotFound(); // Return a 404 Not Found response if the student is not found
            }

            return View(student);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {

            if (email == "admin" && password == "123")
            {
                return RedirectToAction("Student", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Fail";
                return View();
            }
        }

        private string GenerateEmailBody(string courseName)
        {
            string body = $@"
            <p><strong>Xin chào,</strong></p>
            <p>Chúc mừng! Đơn hàng của bạn cho khoá học {courseName} đã được chấp nhận.</p>
            <p>Bây giờ bạn có thể tham gia vào khoá học và bắt đầu học ngay.</p>
            <p>Xin cảm ơn và chúc bạn học tốt!</p>
            <p>Trân trọng,</p>";

            return body;
        }
    }
}
