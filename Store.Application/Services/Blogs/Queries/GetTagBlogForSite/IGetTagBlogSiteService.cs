using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetTagBlogForSite
{
    public interface IGetTagBlogSiteService
    {
        Task<List<ListBlogTagSiteDto>> Execute();
    }
    public class GetTagBlogSiteService : IGetTagBlogSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetTagBlogSiteService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<List<ListBlogTagSiteDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<ListBlogTagSiteDto>
                {
                    
                };
            }
            var tagBlogsSite = _context.BlogTags.Where(q => q.LanguageId == languageId)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            var tagBlogListSite =
            await tagBlogsSite.Where(q => q.IsRemoved == false).Select(r => new ListBlogTagSiteDto
            {
                Id = r.Id,
                Name = r.Name,
            }).ToListAsync();
            return tagBlogListSite;
        }
    }
    public class ListBlogTagSiteDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
