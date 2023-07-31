using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetCategoryBlogForSite
{
    public interface IGetCategoryBlogSiteService
    {
        Task<List<GetCategoryBlogSiteDto>> Execute();
    }
    public class GetCategoryBlogSiteService : IGetCategoryBlogSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetCategoryBlogSiteService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<List<GetCategoryBlogSiteDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetCategoryBlogSiteDto>
                {
                   
                };
            }
            var categoryBlogListSite = _context.CategoryBlogs.Where(q => q.LanguageId == languageId&&q.IsActive).Include(y=>y.ItemCategoryBlogs)
                .OrderByDescending(p => p.InsertTime).AsQueryable();
            var categoryBlogsSite =
            await categoryBlogListSite.Where(q => q.IsRemoved == false).Select(r => new GetCategoryBlogSiteDto
            {
                Id = r.Id,
                Name = r.Name,
                CountSubCategory=r.ItemCategoryBlogs.Count,
            }).ToListAsync();
            return categoryBlogsSite;
        }
    }
    public class GetCategoryBlogSiteDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CountSubCategory { get; set; }
    }
}
