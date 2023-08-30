using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public GetAllPagesSiteService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _language = languege;
            _configuration = configuration;


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
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;

            var checkSlug =await _context.PageCreators.Where((p => p.Slug == Id.Replace("-", " ")||p.Id==Id && p.LanguageId==languageId))
            .Select(w => new GetAllPagesSiteDto
            {
                Title=w.Title,
                Content = w.Content,
                Keywords=w.MetaTagKeyWords,
                MetaDecription=w.MetaTagDescription,
                Image=BaseUrl+w.Image

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
        public string? Image { get; set; }

    }
}
