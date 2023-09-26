using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Roles.Queries.GetAllRole
{
    public interface IGetAllRoleService
    {
        Task<List<GetAllRoleDto>> Execute();
    }
    public class GetAllRoleService : IGetAllRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public GetAllRoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<List<GetAllRoleDto>> Execute()
        {
            var result = await _roleManager.Roles
                .Where(r=>r.IsRemoved==false)
                .OrderByDescending(i=>i.InsertTime)
                .Select(r=>new GetAllRoleDto 
                {
                Id = r.Id,
                Description = r.Description,
                Name = r.Name,
                PersianTitle = r.PersianTitle
                })
                .ToListAsync();
            return result;
        }
    }
    public class GetAllRoleDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? PersianTitle { get; set; }
        public string? Description { get; set; }
    }
}
