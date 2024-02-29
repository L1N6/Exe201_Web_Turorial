using API_NganLuong;
using EXE201_Tutor_Web.Entities;
using Microsoft.AspNetCore.Mvc;

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
            //string payment_method = Request.Form["option_payment"];
            //string str_bankcode = Request.Form["bankcode"];


            //RequestInfo info = new RequestInfo();

            //info.Merchant_id = "67905";
            //info.Merchant_password = "92e7ba12d95eaf88b697949a78c2b277";
            //info.Receiver_email = "thanhdq2302@gmail.com";



            //info.cur_code = "vnd";
            //info.bank_code = str_bankcode;

            //info.Order_code = "ma_don_hang01";
            //info.Total_amount = "10000";
            //info.fee_shipping = "0";
            //info.Discount_amount = "0";
            //info.order_description = "Thanh toan tes thu dong hang";
            //info.return_url = "http://localhost";
            //info.cancel_url = "http://localhost";

            //info.Buyer_fullname = buyer_fullname.Value;
            //info.Buyer_email = buyer_email.Value;
            //info.Buyer_mobile = buyer_mobile.Value;

            //APICheckoutV3 objNLChecout = new APICheckoutV3();
            //ResponseInfo result = objNLChecout.GetUrlCheckout(info, payment_method);

            //if (result.Error_code == "00")
            //{
            //    Response.Redirect(result.Checkout_url);
            //}
            //else
            //    txtserverkt.InnerHtml = result.Description;
            return View();
        }

        [HttpPost]
        public IActionResult Payed(string email, string password)
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
    }
}
