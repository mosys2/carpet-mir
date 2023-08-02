using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Menu.Queries.IGetMenu;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Menu.Queries.IGetMenuForSite
{
    public interface IGetMenuSiteService
    {
        Task<List<MenuItemSiteDto>> Execute();
    }
    public class GetMenuSiteService : IGetMenuSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetMenuSiteService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<List<MenuItemSiteDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<MenuItemSiteDto>
                {
                    
                };
            }
            var MenuItem = await _context.Settings
                .Where(p => p.LanguageId == languageId).FirstOrDefaultAsync();
            if (MenuItem == null)
            {
                return new List<MenuItemSiteDto>
                {
                   
                };
            }
            if (MenuItem.Menu == null)
            {
                return new List<MenuItemSiteDto>
                {
                  
                };
            }
            string menu = MenuItem.Menu;
            List<MenuItemSiteDto> jsonResult = JsonConvert.DeserializeObject<List<MenuItemSiteDto>>(menu);
            return jsonResult;
        }
    }

    public class MenuItemSiteDto
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public string? CssClass { get; set; }
        public List<MenuItemSiteDto>? Sub { get; set; }

    }
}
