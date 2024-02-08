using Microsoft.AspNetCore.Mvc;

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



        [HttpPost]
        public async Task<IActionResult> ExternalLogin(string provider)
        {
            using (HttpClient client = new HttpClient())
            {
              
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        // Đọc nội dung từ phản hồi
                        string content = await res.Content.ReadAsStringAsync();

                        // Trả về view với nội dung đã đọc
                        return Content(content); // hoặc PartialView(content) nếu dữ liệu là một phần tử giao diện
                    }
                    else
                    {
                        // Xử lý khi không thành công
                        return RedirectToAction("SignIn", "Access");
                    }
                }
            }
        }

    }
}
