using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Store.Common.Constant;
using MailKit.Security;
using MimeKit;
using Org.BouncyCastle.Utilities.Net;

namespace Store.Infrastracture.Email
{
    public interface ISendEmailService
    {
        Task<ResultDto> Execute(SendEmailDto sendEmail);
    }
    public class SendEmailService : ISendEmailService
    {
        public async Task<ResultDto> Execute(SendEmailDto sendEmail)
        {
            try
            {
                using (var Client = new SmtpClient())
                {
                    var Credential = new NetworkCredential
                    {
                        UserName = "info@arikehcarpet.com",
                        Password = "arikehcarpet"
                    };
                    Client.Credentials = Credential;
                    Client.Host = "mail.arikehcarpet.com";
                    Client.Port = 25; // or 25  -- 587 -- 465 For Send Email
                    Client.EnableSsl = true;
                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress("mohammadbaghershahmir@gmail.com"));
                        emailMessage.From = new MailAddress("info@arikehcarpet.com");
                        emailMessage.Subject = "aaa";
                        emailMessage.IsBodyHtml = true;
                        emailMessage.Body = $"<div>hello</div>";

                        Client.Send(emailMessage);
                    };
                    await Task.CompletedTask;
                }
                //SmtpClient client = new SmtpClient();
                //client.Port = 587;
                //client.Host = "mail.arikehcarpet.com";
                //client.EnableSsl = true;
                //client.Timeout = 1000000;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                ////در خط بعدی ایمیل  خود و پسورد ایمیل خود  را جایگزین کنید
                //client.Credentials = new NetworkCredential("info@arikehcarpet.com", "arikehcarpet");
                //MailMessage message = new MailMessage("info@arikehcarpet.com", "mohammadbaghershahmir@gmail.com","hich","hicji");
                //message.IsBodyHtml = false;
                //message.BodyEncoding = UTF8Encoding.UTF8;
                //message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                //client.Send(message);

                //Console.WriteLine("ایمیل با موفقیت ارسال شد.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("خطا در ارسال ایمیل: " + ex.Message);
            }

            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.MessageEmail
            };
        }
    }
    public class SendEmailDto
    {
        public string UserEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
