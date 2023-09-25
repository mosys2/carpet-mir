using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Org.BouncyCastle.Asn1.Ocsp;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Profile.Commands.ProfileUpdate;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Profile.Commands.ChangePassword
{
    public interface IChangePasswordService
    {
        Task<ResultDto> Execute(ChangePassDto changePass);
    }
    public class ChangePasswordService : IChangePasswordService
    {
        private readonly IDatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public ChangePasswordService(IDatabaseContext context,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ResultDto> Execute(ChangePassDto changePass)
        {
            var user = await _userManager.FindByEmailAsync(changePass.Email);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotExistsUser
                };
            }
            //CheckPassword
            try
            {

                var checkchangePass = await _userManager.ChangePasswordAsync(user, changePass.OldPassword, changePass.NewPassword);
                if (!checkchangePass.Succeeded)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = MessageInUser.MessageInvalidOldPassword
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }

            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.MessageChangePassword
            };
        }
    }
    public class ChangePassDto
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class ChangePassModel
    {
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "وارد کردن رمزعبور قبلی الزامی است.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "وارد کردن رمزعبور الزامی است.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "وارد کردن تکرار رمزعبور الزامی است.")]
        [Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        public string? ReNewPassword { get; set; }
    }
}
