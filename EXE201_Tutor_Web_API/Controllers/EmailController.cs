using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Services.MailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static EXE201_Tutor_Web_API.Constant.Enum;

namespace EXE201_Tutor_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ISendMailService _sendMailService;

        public EmailController(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailAsync(MailContentDto mailContentDto)
        {
            SendMailResult result = await _sendMailService.SendMail(mailContentDto);
            if (result == SendMailResult.Failed)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
