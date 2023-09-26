using Microsoft.AspNetCore.Identity;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Roles.Commands.RemoveRole
{
    public interface IRemoveRoleService
    {
        Task<ResultDto> Execute(string IdRole);
    }
    public class RemoveRoleService : IRemoveRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RemoveRoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<ResultDto> Execute(string IdRole)
        {
            var role=await _roleManager.FindByIdAsync(IdRole);
            if(role == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            role.IsRemoved = true;
            role.RemoveTime = DateTime.Now;
            await _roleManager.UpdateAsync(role);
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.Delete
            };
        }
    }
}
