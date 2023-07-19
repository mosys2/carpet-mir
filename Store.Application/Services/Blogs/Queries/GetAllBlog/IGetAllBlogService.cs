using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetAllBlog
{
    public interface IGetAllBlogService
    {
        Task<ResultDto<List<GetAllBlogDto>>> Execute(string? LanguegeId);
    }
    public class GetAllBlogService : IGetAllBlogService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;

        public GetAllBlogService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ResultDto<List<GetAllBlogDto>>> Execute(string? LanguegeId)
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var BlogList = _context.Blogs.Include(q => q.Language)
                .Include(a=>a.Author)
                .Include(q=>q.ItemCategoryBlogs)
                .OrderByDescending(p => p.InsertTime).AsQueryable();
            if (!string.IsNullOrEmpty(LanguegeId))
            {
                BlogList = BlogList.Where(l => l.LanguageId == LanguegeId);
            }
            var Blogs =
            await BlogList.Where(q => q.IsRemoved == false).Select(r => new GetAllBlogDto
            {
                Id = r.Id,
                Description= r.Description,
                Author=r.Author.Name,
                CategoryBlog=r.ItemCategoryBlogs.Select(y=>new TagBlogsListDto
                {
                    Id=y.Id,
                    Name=y.CategoryBlog.Name
                }).ToList(),
                Content=r.Content,
                Image=BaseUrl+r.Pic,
                IsActive=r.State,
                Title=r.Title,
                View=r.View,
            }).ToListAsync();
            return new ResultDto<List<GetAllBlogDto>>()
            {
                Data = Blogs,
                IsSuccess = true
            };
        }
    }
    public class TagBlogsListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class GetAllBlogDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public List<TagBlogsListDto> CategoryBlog { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public int View { get; set; }
    }
}
