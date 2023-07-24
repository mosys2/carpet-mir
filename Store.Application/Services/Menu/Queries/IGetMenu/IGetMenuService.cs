using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ContactsUs.Commands.AddNewContactUsForSite;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Store.Application.Services.Menu.Queries.IGetMenu
{
    public interface IGetMenuService
    {
        Task<ResultDto<List<MenuItemDto>>> Execute(string? LanguegeId);
    }
    public class GetMenuService : IGetMenuService
    {
        private readonly IDatabaseContext _context;
        public GetMenuService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<MenuItemDto>>> Execute(string? LanguegeId)
        {
            var MenuItem = _context.Settings.AsQueryable();
            if (!string.IsNullOrEmpty(LanguegeId))
            {
                MenuItem = MenuItem.Where(w => w.LanguageId == LanguegeId);
            }
            if (MenuItem == null)
            {
                return new ResultDto<List<MenuItemDto>>()
                {
                    IsSuccess=false,
                    Message=MessageInUser.NotFind
                };
            }
            string menu = MenuItem.FirstOrDefault().Menu;
            List<MenuItemDto> jsonResult = JsonConvert.DeserializeObject<List<MenuItemDto>>(menu);
            return new ResultDto<List<MenuItemDto>>
            {
                Data = jsonResult,
                IsSuccess = true
            };
        }
    }
    public class MenuItemDto
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public string? CssClass { get; set; }
        public List<MenuItemDto>? Sub { get; set; }

    }
}
