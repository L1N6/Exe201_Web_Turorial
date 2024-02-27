using EXE201_Tutor_Web.Models;
using EXE201_Tutor_Web.Service.VnPayService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EXE201_Tutor_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VnPayService _vnPayService;

        public HomeController(ILogger<HomeController> logger, VnPayService vnPayService)
        {
            _logger = logger;
            _vnPayService = vnPayService;
        }

        public IActionResult Index()
        {

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