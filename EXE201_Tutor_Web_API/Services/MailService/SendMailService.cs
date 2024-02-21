using EXE201_Tutor_Web_API.Dto;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using static EXE201_Tutor_Web_API.Constant.Enum;

namespace EXE201_Tutor_Web_API.Services.MailService
{
    public class SendMailService : ISendMailService
    {
        private readonly MailSettingDto mailSettings;

        private readonly ILogger<SendMailService> logger;
        public SendMailService(IOptions<MailSettingDto> _mailSettings, ILogger<SendMailService> _logger)
        {
            mailSettings = _mailSettings.Value;
            logger = _logger;
            logger.LogInformation("Create SendMailService");
        }

        // Gửi email, theo nội dung trong mailContent
        public async Task<SendMailResult> SendMail(MailContentDto mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
            email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            

            string filePath = "D:\\FBT_DaiHocDauHangCongNghe\\SPRING24\\PRN231\\Code\\EXE201_Tutor_Web\\EXE201_Tutor_Web\\wwwroot\\doc\\My_name_is_name.docx";
            byte[] fileBytes;
            
            if (System.IO.File.Exists(filePath))
            {
                FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using(var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes= ms.ToArray();
                }
                builder.Attachments.Add("attachment.docx", fileBytes, ContentType.Parse("application/octet-stream"));
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
            return await SendMail(new MailContentDto()
            {
                To = email,
                Subject = subject,
                Body = htmlMessage
            });
        }
    }
}
