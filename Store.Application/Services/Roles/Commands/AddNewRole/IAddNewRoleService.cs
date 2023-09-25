using Microsoft.AspNetCore.Identity;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Authors.Commands.AddNewAuthor;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Roles.Commands.AddNewRole
{
    public interface IAddNewRoleService
    {
        Task<ResultDto> Excute(RoleDto role);
    }
    public class AddNewRoleService : IAddNewRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public AddNewRoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<ResultDto> Excute(RoleDto role)
        {
            if(role.Id!=null)
            {
                var editRole = await _roleManager.FindByIdAsync(role.Id);
                editRole.Name=role.Name;
                editRole.PersianTitle = role.PersianTitle;
                editRole.Description = role.Description;
                editRole.NormalizedName = role.Name.ToUpper();
                editRole.UpdateTime = DateTime.Now;
               await _roleManager.UpdateAsync(editRole);
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageUpdate
                };
            }

            Role roleCreate = new Role()
            {
                Id=Guid.NewGuid().ToString(),
                Name=role.Name,
                PersianTitle=role.PersianTitle,
                Description = role.Description,
                NormalizedName=role.Name.ToUpper(),
                InsertTime =DateTime.Now,
            };
            var result=await _roleManager.CreateAsync(roleCreate);
            if (result.Succeeded)
            {
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageInsert
                };
            }
            else
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageInvalidOperation
                };
            }
        }
    }
    public class RoleDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? PersianTitle { get; set; }
        public string? NormalizedName { get; set; }
        public string? Description { get; set; }
    }
}
