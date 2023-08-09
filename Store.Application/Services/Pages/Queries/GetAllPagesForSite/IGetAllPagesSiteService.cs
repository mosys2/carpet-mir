using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;
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
        Task<GetAllPagesSiteDto> Execute(string SlugOrId);
    }
    public class GetAllPagesSiteService : IGetAllPagesSiteService
    {

        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllPagesSiteService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<GetAllPagesSiteDto> Execute(string Id)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new GetAllPagesSiteDto
                {

                };
            }
            var checkSlug =await _context.PageCreators.Where(p => p.Slug == Id.Replace("-", " ")||p.Id==Id)
            .Select(w => new GetAllPagesSiteDto
            {
                Title=w.Title,
                Content = w.Content,
                Keywords=w.MetaTagKeyWords,
                MetaDecription=w.MetaTagDescription,

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
        public string? Keywords { get; set; }
        public string? MetaDecription { get; set; }

    }
}
