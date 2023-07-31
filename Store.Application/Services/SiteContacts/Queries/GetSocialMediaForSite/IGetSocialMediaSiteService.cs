using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetTagBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite
{
    public interface IGetSocialMediaSiteService
    {
        Task<List<GetSocialMediaSiteDto>> Execute();
    }
    public class GetSocialMediaSiteService : IGetSocialMediaSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetSocialMediaSiteService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<List<GetSocialMediaSiteDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetSocialMediaSiteDto>
                {

                };
            }
            var socialMediaSite = _context.SiteContacts.Where(q => q.LanguageId == languageId && q.IsActive)
                .Include(w=>w.SiteContactType) 
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            var socialMediaSiteList =
            await socialMediaSite.Where(q => q.IsRemoved == false&&q.SiteContactType.Value== ContactsTypeValue.SocialMedia).Select(r => new GetSocialMediaSiteDto
            {
                Name = r.Title,
                CssClass=r.CssClass,
                Link=r.Value
            }).ToListAsync();
            return socialMediaSiteList;
        }
    }
    public class GetSocialMediaSiteDto
    {
        public string? Name { get; set; }
        public string? CssClass { get; set; }
        public string? Link { get; set; }
    }
}
