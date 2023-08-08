﻿using Store.Common.Dto;
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

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "webmail.arikehcarpet.com";
                client.EnableSsl = true;
                client.Timeout = 1000000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //در خط بعدی ایمیل  خود و پسورد ایمیل خود  را جایگزین کنید
                client.Credentials = new NetworkCredential("info@arikehcarpet.com", "arikehcarpet");
                MailMessage message = new MailMessage("info@arikehcarpet.com", "mohammadbaghershahmir@gmail.com","hich","hicji");
                message.IsBodyHtml = false;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                client.Send(message);

                Console.WriteLine("ایمیل با موفقیت ارسال شد.");
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