using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetAdminUsersService
    {
        Task<List<AdminUserDto>> Execute(string? role);
    }
    public class GetAdminUsersService : IGetAdminUsersService
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;
        public GetAdminUsersService( IDatabaseContext databaseContext, UserManager<User> userManager)
        {
            _databaseContext= databaseContext;
            _userManager=userManager;
        }
        public async Task<List<AdminUserDto>> Execute(string? role)
        {
            var users = _databaseContext.Users.AsQueryable();
            if(role == null)
            {
                var allUsers=await users.Select(p => new AdminUserDto
                {
                    Email=p.Email,
                    FullName=p.FullName,
                    PhoneNumber=p.PhoneNumber
                }).ToListAsync();
                return allUsers;
            }
            else
            {
                var userInRoll =_userManager.GetUsersInRoleAsync(role).Result.Select(p => new AdminUserDto
                {
                    Email=p.Email,
                    FullName=p.FullName,
                    PhoneNumber=p.PhoneNumber
                }).ToList();
                return userInRoll;
            }
        }
    }
    public class AdminUserDto
    {
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
