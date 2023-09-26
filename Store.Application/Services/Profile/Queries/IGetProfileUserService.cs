using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using Store.Common.Constant.NoImage;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Store.Application.Services.Profile.Queries
{
    public interface IGetProfileUserService
    {
        Task<GetProfileUserDto> Execute(string Id);
    }
    public class GetProfileUserService : IGetProfileUserService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public GetProfileUserService(IDatabaseContext context,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<GetProfileUserDto> Execute(string Id)
        {
            var user =await _context.Users.FindAsync(Id);
            if(user==null)
            {
                return new GetProfileUserDto { };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var listRol = await _userManager.GetRolesAsync(user);
            return new GetProfileUserDto
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                UserName = user.UserName,
                PhoneNumber=user.PhoneNumber,
                Address=user.Address,
                Role=listRol.ToArray(),
                Image =string.IsNullOrEmpty(user.ProfileImage)? ImageProductConst.ProfileAdmin :user.ProfileImage
            };
        }
    }
    public class GetProfileUserDto
    {
        public string Id { get; set; }
        public string? FullName  { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string[]? Role { get; set; }
    }

}
