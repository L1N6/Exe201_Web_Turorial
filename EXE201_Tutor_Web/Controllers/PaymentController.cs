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
            return View();
        }

        [HttpPost]
        public IActionResult Payed(string bankcode, string buyer_fullname, string buyer_email, string buyer_mobile, int courseraId)
        {

            
            string payment_method = "ATM_ONLINE";
            string str_bankcode = bankcode;
            RequestInfo info = new RequestInfo();

            info.Merchant_id = "67905";
            info.Merchant_password = "92e7ba12d95eaf88b697949a78c2b277";
            info.Receiver_email = "thanhdq2302@gmail.com";
            info.cur_code = "vnd";
            info.bank_code = str_bankcode;
            info.Order_code = GenerateRandomString(10);
            info.Total_amount = _context.Courseras.FirstOrDefault(x => x.CourseraId == courseraId).Money.ToString();
            info.fee_shipping = "0";
            info.Discount_amount = "0";
            info.order_description = "Thanh toan tes thu dong hang";
            info.return_url = "http://localhost";
            info.cancel_url = "http://localhost";
            info.Buyer_fullname = buyer_fullname;
            info.Buyer_email = buyer_email;
            info.Buyer_mobile = buyer_mobile;

            APICheckoutV3 objNLChecout = new APICheckoutV3();
            ResponseInfo result = objNLChecout.GetUrlCheckout(info, payment_method);

            if (result.Error_code == "00")
            {
                Response.Redirect(result.Checkout_url);
            }
            
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
    }
}
