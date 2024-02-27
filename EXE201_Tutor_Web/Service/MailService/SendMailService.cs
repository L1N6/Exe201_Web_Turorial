using EXE201_Tutor_Web.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EXE201_Tutor_Web_API.Services.MailService
{
    public enum SendMailResult
    {
        Success,
        Failed
    }
    public class SendMailService : ISendMailService
    {
        private readonly MailSetting mailSettings;

        private readonly ILogger<SendMailService> logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SendMailService(IOptions<MailSetting> _mailSettings, ILogger<SendMailService> _logger, IWebHostEnvironment webHostEnvironment)
        {
            mailSettings = _mailSettings.Value;
            logger = _logger;
            logger.LogInformation("Create SendMailService");
            _webHostEnvironment = webHostEnvironment;
        }

        // Gửi email, theo nội dung trong mailContent
        public async Task<SendMailResult> SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
            email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;


            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "doc");
            string filePath = Path.Combine(folderPath, mailContent.fileName);
            byte[] fileBytes;

            if (System.IO.File.Exists(filePath))
            {
                FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
                builder.Attachments.Add(mailContent.fileName, fileBytes, ContentType.Parse("application/octet-stream"));
            }
            email.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                System.IO.Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await email.WriteToAsync(emailsavefile);

                logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
                logger.LogError(ex.Message);
                return SendMailResult.Failed;
            }

            smtp.Disconnect(true);

            logger.LogInformation("send mail to " + mailContent.To);
            return SendMailResult.Success;
        }
        public async Task<SendMailResult> SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return await SendMail(new MailContent()
            {
                To = email,
                Subject = subject,
                Body = htmlMessage
            });
        }
    }
}
