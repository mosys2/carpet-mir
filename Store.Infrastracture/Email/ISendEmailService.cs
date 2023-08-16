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
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Org.BouncyCastle.Utilities.Net;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Store.Infrastracture.Email
{
    public interface ISendEmailService
    {
        Task<ResultDto> Execute(SendEmailDto sendEmail);
    }
    public class SendEmailService : ISendEmailService
    {
        private readonly MailSettings _mailSettings;
        public SendEmailService(IOptions<MailSettings> mailSettingsOptions)
        {
            _mailSettings = mailSettingsOptions.Value;
        }
        public async Task<ResultDto> Execute(SendEmailDto sendEmail)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(_mailSettings.SenderName,_mailSettings.SenderEmail));
                email.To.Add(new MailboxAddress(sendEmail.Name, sendEmail.UserEmail));
                email.Subject = sendEmail.Subject;
                
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = sendEmail.Body
                };
                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.SslProtocols=System.Security.Authentication.SslProtocols.Tls;
                    smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    smtp.CheckCertificateRevocation = false;
                    smtp.Connect(_mailSettings.Server, _mailSettings.Port,true);
                    smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageEmailError
                };
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
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
    public class MailSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
