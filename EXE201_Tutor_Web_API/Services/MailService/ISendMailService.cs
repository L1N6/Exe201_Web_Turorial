using EXE201_Tutor_Web_API.Dto;
using static EXE201_Tutor_Web_API.Constant.Enum;

namespace EXE201_Tutor_Web_API.Services.MailService
{
    public interface ISendMailService
    {
        Task<SendMailResult> SendMail(MailContentDto mailContent);

        Task<SendMailResult> SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
