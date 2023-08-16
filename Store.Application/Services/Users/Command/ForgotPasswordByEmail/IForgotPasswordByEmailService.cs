using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Results;
using Store.Domain.Entities.Users;
using Store.Infrastracture.Email;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace Store.Application.Services.Users.Command.ForgotPasswordByEmail
{
    public interface IForgotPasswordByEmailService
    {
        Task<ResultDto> CheckEmail(ForgotPasswordConfirmationDto forgotPassword);
        Task<ResultDto> ResetPassword(ResetPasswordDto resetPassword);

    }
    public class ForgotPasswordByEmailService : IForgotPasswordByEmailService
    {
        private readonly UserManager<User> _userManager;
        private readonly ISendEmailService _sendEmailService;
        private readonly IConfiguration _configuration;
        public ForgotPasswordByEmailService(UserManager<User> UserManager
            ,ISendEmailService SendEmailService
            , IConfiguration configuration
            )
        {
            _userManager = UserManager;
            _sendEmailService = SendEmailService;
            _configuration = configuration;
        }
        public async Task<ResultDto> CheckEmail(ForgotPasswordConfirmationDto forgotPassword)
        {
            var user =await _userManager.FindByEmailAsync(forgotPassword.Email);
            if (user == null /*|| _userManager.IsEmailConfirmedAsync(user).Result == false*/)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.InvalidEmail,
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            string token =await _userManager.GeneratePasswordResetTokenAsync(user);

            string callbakUrl = BaseUrl + "/Admin/Account/ResetPassword" + "?userId=" + user.Id + "&token" + token;
            string body = $"برای تنظیم مجدد کلمه عبور بر روی لینک زیر کلیک کنید <br/> <a href={callbakUrl}> Link Reset Password </a>";
            var result =await _sendEmailService.Execute(
                 new SendEmailDto
                 {
                     Body = body,
                     Subject = "فراموشی رمز عبور",
                     UserEmail = user.Email
                 }
                 );
            return result;
        }

        public async Task<ResultDto> ResetPassword(ResetPasswordDto resetPassword)
        {
            if (resetPassword.Password != resetPassword.ConfirmPassword)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessagePass,
                };
            }
            var user =await _userManager.FindByIdAsync(resetPassword.UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageNotFind,
                };
            }
            var Result =await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (Result.Succeeded)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageChangePassword,
                };

            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageInvalidChangePassword,
                };
            }

        }
    }
    public class ForgotPasswordConfirmationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
    public class ResetPasswordDto
    {

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }

    }
}
