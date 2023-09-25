using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Org.BouncyCastle.Asn1.Ocsp;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Pages.Commands.EditPageCreator;
using Store.Application.Services.Profile.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Profile.Commands.ProfileUpdate
{
    public interface IProfileUpdateService
    {
        Task<ResultDto> Execute(UpdateProfileDto updateProfile);
    }
    public class ProfileUpdateService : IProfileUpdateService
    {
        private readonly IDatabaseContext _context;
        private readonly UserManager<User> _userManager;
        public ProfileUpdateService(IDatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ResultDto> Execute(UpdateProfileDto updateProfile)
        {
            var user = await _context.Users.FindAsync(updateProfile.Id);
            if (user == null)
            {
                return new ResultDto
                {
                IsSuccess= false,
                Message=MessageInUser.NotExistsUser
                };
            }
            //CheckPassword
            var pass = await _userManager.CheckPasswordAsync(user, updateProfile.Password);
            if(!pass)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageInvalidPassword
                };
            }
            //Update Profile
            user.Address = updateProfile.Address;
            user.PhoneNumber=updateProfile.PhoneNumber;
            user.ProfileImage =string.IsNullOrEmpty(updateProfile.Image)?user.ProfileImage:updateProfile.Image;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.MessageUpdateProfile
            };
        }
    }
    public class UpdateProfileDto
    {
        [Required]
        public string Id { get; set; }
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
