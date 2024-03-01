using API_NganLuong;
using EXE201_Tutor_Web.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EXE201_Tutor_Web.Controllers
{
    public class PaymentController : Controller
    {
        public readonly EXE_DataBaseContext _context;
        public PaymentController(EXE_DataBaseContext context)
        {
            _context = context;
        }
        public IActionResult PayCoursera(int id)
        {
            TempData["ErrorMessage"] = TempData.ContainsKey("ErrorMessage") ? TempData["ErrorMessage"].ToString() : "";
            TempData["CourseraId"] = TempData.ContainsKey("CourseraId") ? TempData["CourseraId"].ToString() : id;
            return View();
        }

        [HttpPost]
        public ActionResult PayCoursera(string bankcode, string buyer_fullname, string buyer_email, string buyer_mobile, int courseraId)
        {

            
            string payment_method = "ATM_ONLINE";
            RequestInfo info = new RequestInfo();

            info.Merchant_id = "52756";
            info.Merchant_password = "d9b7a7f7f93d0fb54f7d751c6bbd6c97";
            info.Receiver_email = "thanhdq2302@gmail.com";
            info.cur_code = "vnd";
            info.bank_code = bankcode;
            info.Order_code = GenerateRandomString(10);
            var coursera = _context.Courseras.FirstOrDefault(x => x.CourseraId == courseraId);
            info.Total_amount = coursera != null  ? coursera.Money.ToString() : "10000" ;
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
            if (result.errorCode == "00")
            {
                return View();
            }
            else
            {
                TempData["CourseraId"] = courseraId;
                TempData["ErrorMessage"] = "Có lỗi gì đang xảy ra vui lòng kiểm tra lại";
                return RedirectToAction("PayCoursera", "Payment");
            }
            
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
        

    }
}
