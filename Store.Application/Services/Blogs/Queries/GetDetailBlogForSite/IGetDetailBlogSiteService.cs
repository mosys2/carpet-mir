using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetDetailBlogForSite
{
    public interface IGetDetailBlogSiteService
    {
        Task<ResultDto<GetDetailBlogSiteDto>> Execute(string Id);
    }
    public class GetDetailBlogSiteService : IGetDetailBlogSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetDetailBlogSiteService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _language = languege;
        }
        public async Task<ResultDto<GetDetailBlogSiteDto>> Execute(string Id)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<GetDetailBlogSiteDto>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var FindBlog = _context.Blogs.Include(s => s.Author).Include(i => i.ItemCategoryBlogs).ThenInclude(d=>d.CategoryBlog)
                .Include(m => m.BlogItemTags).ThenInclude(p=>p.BlogTag)
                .Where(p => p.LanguageId == languageId && p.Id == Id).FirstOrDefault();
            if (FindBlog == null)
            {
                return new ResultDto<GetDetailBlogSiteDto>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            return new ResultDto<GetDetailBlogSiteDto>
            {
                Data = new GetDetailBlogSiteDto
                {
                    Author = FindBlog.Author.Name,
                    Category = FindBlog.ItemCategoryBlogs.Select(w => new BlogCategoryDto
                    {
                        Id = w.CategoryBlog.Id,
                        Name = w.CategoryBlog.Name,

                    }).ToList(),
                    Tags = FindBlog.BlogItemTags.Select(r => new BlogTagDto
                    {
                        Id = r.BlogTag.Id,
                        Name = r.BlogTag.Name,
                    }).ToList(),
                    Content = FindBlog.Content,
                    Description = FindBlog.Description,
                    Image = BaseUrl + FindBlog.Pic,
                    InsertTime = FindBlog.InsertTime.Value.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
                    Title = FindBlog.Title,
                }
            };
        }
    }
    public class BlogTagDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
    public class BlogCategoryDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
    public class GetDetailBlogSiteDto
    {
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? InsertTime { get; set; }
        public List<BlogCategoryDto>? Category { get; set; }
        public List<BlogTagDto>? Tags { get; set; }
        public string? Content { get; set; }
    }
}
