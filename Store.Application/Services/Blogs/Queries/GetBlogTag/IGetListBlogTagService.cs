using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Dto;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetBlogTag
{
    public interface IGetListBlogTagService
    {
        Task <List<ListBlogTagDto>> Execute();
    }
    public class GetListBlogTagService : IGetListBlogTagService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetListBlogTagService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<List<ListBlogTagDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<ListBlogTagDto>
                {
                    
                };
            }
            var tagBlogs = _context.BlogTags.Where(q => q.LanguageId == languageId)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            
            var tagBlogList =
            await tagBlogs.Where(q => q.IsRemoved == false).Select(r => new ListBlogTagDto
            {
                Id = r.Id,
                Name = r.Name,
            }).ToListAsync();
            return tagBlogList;
        }
    }
    public class ListBlogTagDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
