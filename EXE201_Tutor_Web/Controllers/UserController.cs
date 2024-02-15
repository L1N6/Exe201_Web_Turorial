using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

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

        [HttpGet]
        public IActionResult ExternalLogin(string returnUrl = "/")
        {
            // Chuyển hướng đến hành động đăng nhập của API
            return Redirect("http://localhost:5052/api/Login/google-login?returnUrl=%2F");
        }

        [HttpGet]
        public async Task<IActionResult> HandleExternalLogin(string returnUrl = "/")
        {
            // Gọi API để lấy kết quả
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7184/api/Login/google-response?ReturnUrl=%2F");

            if (response.IsSuccessStatusCode)
            {
                // Đọc nội dung phản hồi
                string responseBody = await response.Content.ReadAsStringAsync();

                // Xử lý kết quả và trả về một trang với dữ liệu từ kết quả API
                ViewData["Result"] = responseBody;
                ViewData["ReturnUrl"] = returnUrl;
                return RedirectToAction("Access", "SignIn");
            }
            else
            {
                // Xử lý trường hợp API không thành công
                return View("Error");
            }
        }


    }
}
