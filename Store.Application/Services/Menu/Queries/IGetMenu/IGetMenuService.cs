using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ContactsUs.Commands.AddNewContactUsForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SettingsSite.Queries;
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
        Task<ResultDto<List<MenuItemDto>>> Execute();
    }
    public class GetMenuService : IGetMenuService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetMenuService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto<List<MenuItemDto>>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<List<MenuItemDto>>
                {
                    IsSuccess=false
                };
            }
            var MenuItem = await _context.Settings
                .Where(p => p.LanguageId == languageId).FirstOrDefaultAsync();
            if (MenuItem == null)
            {
                return new ResultDto<List<MenuItemDto>>()
                {
                    IsSuccess=false,
                    Message=MessageInUser.NotFind
                };
            }
            if (MenuItem.Menu==null)
            {
                return new ResultDto<List<MenuItemDto>>
                {
                    IsSuccess = true,
                    Id=MenuItem.Id
                };
            }
            string menu = MenuItem.Menu;
            List<MenuItemDto> jsonResult = JsonConvert.DeserializeObject<List<MenuItemDto>>(menu);
            return new ResultDto<List<MenuItemDto>>
            {
                Data = jsonResult,
                IsSuccess = true,
                Id=MenuItem.Id
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
