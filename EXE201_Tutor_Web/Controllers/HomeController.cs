using EXE201_Tutor_Web.Entities;
using EXE201_Tutor_Web.Models;
using EXE201_Tutor_Web.Service.VnPayService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EXE201_Tutor_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VnPayService _vnPayService;
        public readonly EXE_DataBaseContext _context;

        public HomeController(EXE_DataBaseContext context, ILogger<HomeController> logger, VnPayService vnPayService)
        {
            _context = context;
            _logger = logger;
            _vnPayService = vnPayService;
        }

        public IActionResult Index()
        {
            List<Feedback> feedbacks = _context.Feedbacks
                .Include(f => f.Student)
                .ToList();
            TempData["listFeedBack"] = feedbacks;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}