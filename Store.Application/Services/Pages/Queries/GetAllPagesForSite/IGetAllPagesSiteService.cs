using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;
using Store.Common.Constant.GroupTypes;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Pages.Queries.GetAllPagesForSite
{
    public interface IGetAllPagesSiteService
    {
        Task<GetAllPagesSiteDto> Execute(string SlugOrId,GroupType? groupType);
    }
    public class GetAllPagesSiteService : IGetAllPagesSiteService
    {

        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        private readonly IConfiguration _configuration;

        public GetAllPagesSiteService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _language = languege;
            _configuration = configuration;


        }
        public async Task<GetAllPagesSiteDto> Execute(string SlugOrId, GroupType? groupType)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new GetAllPagesSiteDto
                {

                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var listPages = _context.PageCreators
                .Include(w => w.GroupItem)
                .Where(i => i.LanguageId == languageId&&i.IsActive).AsQueryable();
            var idItemGroup = "";
            if (groupType!=null)
            {
                 idItemGroup = listPages.Where(o => o.GroupItem.GroupType == groupType).FirstOrDefault()?.GroupItem.Id;
            }
            if(idItemGroup!=null&&SlugOrId!="")
            {
                idItemGroup = "";
            }
            var checkSlug =await listPages.Where(p => (p.Slug == SlugOrId.Replace("-", " ") || p.Id == SlugOrId)|| p.GroupItemId== idItemGroup)
            .Select(w => new GetAllPagesSiteDto
            {
                Title=w.Title,
                Content = w.Content,
                Keywords=w.MetaTagKeyWords,
                MetaDecription=w.MetaTagDescription,
                Image=BaseUrl+w.Image,
                GroupType=w.GroupItem.GroupType,
            }).FirstOrDefaultAsync();
            if(checkSlug==null)
            {
                return new GetAllPagesSiteDto
                {
                 
                };
            }
            return checkSlug;
        }
    }
    public class GetAllPagesSiteDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public GroupType? GroupType  { get; set; }
        public string? Keywords { get; set; }
        public string? MetaDecription { get; set; }
        public string? Image { get; set; }

    }
}
