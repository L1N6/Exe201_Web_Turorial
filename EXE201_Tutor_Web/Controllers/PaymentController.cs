using API_NganLuong;
using EXE201_Tutor_Web.Entities;
using EXE201_Tutor_Web.Models;
using EXE201_Tutor_Web_API.Services.MailService;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EXE201_Tutor_Web.Controllers
{
    public class PaymentController : Controller
    {
        public readonly EXE_DataBaseContext _context;
        private readonly ISendMailService _mailService;

        public PaymentController(EXE_DataBaseContext context, ISendMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }
        public IActionResult PayCoursera(int id)
        {
            TempData["ErrorMessage"] = TempData.ContainsKey("ErrorMessage") ? TempData["ErrorMessage"].ToString() : "";
            TempData["CourseraId"] = TempData.ContainsKey("CourseraId") ? TempData["CourseraId"].ToString() : 1;
            return View();
        }

        [HttpPost]
        public ActionResult PayCoursera( string bankcode, string buyer_fullname, string buyer_email, string buyer_mobile, int courseraId)
        {
            
                    RequestInfo info = new RequestInfo();
                    string payment_method = "ATM_ONLINE";
                    info.Merchant_id = "52756";
                    info.Merchant_password = "d9b7a7f7f93d0fb54f7d751c6bbd6c97";
                    info.Receiver_email = "thanhdq2302@gmail.com";
                    info.cur_code = "vnd";
                    info.bank_code = bankcode;
                    info.Order_code = GenerateRandomString(10);
                    var coursera = _context.Courseras.FirstOrDefault(x => x.CourseraId == courseraId);
                    info.Total_amount = coursera != null ? coursera.Money.ToString() : "10000";
                    info.order_description = courseraId.ToString();
                    info.fee_shipping = "0";
                    info.Discount_amount = "0";
                    info.return_url = "https://localhost:7084/Payment/PayedReturn";
                    info.cancel_url = "http://localhost";
                    info.Buyer_fullname = buyer_fullname;
                    info.Buyer_email = buyer_email;
                    info.Buyer_mobile = buyer_mobile;

                    APICheckoutV3 objNLChecout = new APICheckoutV3();
                    ResponseInfo result = objNLChecout.GetUrlCheckout(info, payment_method);

                    if (!(result.Error_code == "00"))
                    {
                        TempData["CourseraId"] = courseraId;
                        TempData["ErrorMessage"] = result.Description;
                        return RedirectToAction("PayCoursera", "Payment");
                    }
                    return Redirect(result.Checkout_url);
        }


        public IActionResult PayedReturn(string token)
        {
            
            RequestCheckOrder info = new RequestCheckOrder();
            info.Merchant_id = "52756";
            info.Merchant_password = "d9b7a7f7f93d0fb54f7d751c6bbd6c97";
            info.Token = token;
            APICheckoutV3 objNLChecout = new APICheckoutV3();
            ResponseCheckOrder result = objNLChecout.GetTransactionDetail(info);
            int courseraId = Int32.Parse(result.description);
            var coursera = _context.Courseras.FirstOrDefault(x => x.CourseraId == courseraId);

            if (result.errorCode == "00")
            {
                OrderCoursera order = new OrderCoursera
                {
                    CourseraId = courseraId,
                    Money = double.Parse(result.paymentAmount),
                    StudentId = 1,
                    Status = true,
                    Email = result.payerEmail,
                    DateAccepted = DateTime.Now,
                };

                _context.OrderCourseras.Add(order);
               

                MailContent content = new MailContent
                {
                    To = result.payerEmail,
                    Subject = "Order Coursera",
                    Body = GenerateEmailBody(coursera.Name),

                };
                _mailService.SendMail(content);

                OnCoursera onCoursera = new OnCoursera
                {
                    CourseraId = coursera.CourseraId,
                    StudentId = 1,
                    Date = DateTime.Now
                };
                _context.OnCoursera.Add(onCoursera);

                _context.SaveChanges();
                return View();
            }
            else
            {
                TempData["CourseraId"] = courseraId;
                TempData["ErrorMessage"] = "Có lỗi gì đang xảy ra vui lòng kiểm tra lại";
                return RedirectToAction("PayCoursera", "Payment");
            }
            
        }

        public IActionResult PayByFacebook(int id)
        {
            var coursera = _context.Courseras.FirstOrDefault(x => x.CourseraId == id);
            TempData["bankDescription"] = GenerateRandomNumberString(20);
            TempData["amount"] = coursera.Money.ToString();
            TempData["CourseraId"] = id;
            return View();

        }

        [HttpPost]
        public ActionResult PayByFacebook(int courseraId, string? voucher, string bankDescription)
        {
            var coursera = _context.Courseras.FirstOrDefault(x => x.CourseraId == courseraId);
            TempData["bankDescription"] = bankDescription;
            TempData["amount"] = coursera.Money - coursera.Money*0.3;
            TempData["CourseraId"] = courseraId;
            return View();
        }

        [HttpPost]
        public ActionResult PayedReturn(int courseraId, double amount, string bankDescription, string email)
        {
            OrderCoursera order = new OrderCoursera
            {
                CourseraId = courseraId,
                Money = amount,
                StudentId = 1,
                BankDescription = bankDescription,
                Status = false,
                Email = email

            };
            _context.OrderCourseras.Add(order);
            _context.SaveChanges();
            return View();
        }


        public string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }

            return stringBuilder.ToString();
        }
        public string GenerateRandomNumberString(int length)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(random.Next(10)); // Append a random digit (0-9)
            }

            return sb.ToString();
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
