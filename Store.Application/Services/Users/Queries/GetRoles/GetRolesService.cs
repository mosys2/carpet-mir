﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly RoleManager<Role> _roleManager;

        public GetRolesService(RoleManager<Role> roleManager)
        {
          _roleManager = roleManager;
        }

        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _roleManager.Roles.Select(
                o=>new RolesDto
                {
                    Name = o.Name,
                    PersianTitle = o.PersianTitle,
                    Description = o.Description,
                    Id=o.Id
                }
                ).ToList();
            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
