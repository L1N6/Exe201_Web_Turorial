using EXE201_Tutor_Web.Models;
namespace EXE201_Tutor_Web_API.Services.MailService
{
    public interface ISendMailService
    {
        Task<SendMailResult> SendMail(MailContent mailContent);

        Task<SendMailResult> SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
