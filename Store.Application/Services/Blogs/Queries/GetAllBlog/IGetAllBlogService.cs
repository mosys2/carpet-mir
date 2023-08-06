using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetProductsList;
using Store.Common;
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
        Task<ResultGetBlogDto> Execute(RequestGetBlogDto requestGetBlog);
    }
    public class GetAllBlogService : IGetAllBlogService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllBlogService(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices language)
        {
            _context = context;
            _configuration = configuration;
            _language= language;
        }
        public async Task<ResultGetBlogDto> Execute(RequestGetBlogDto requestGetBlog)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultGetBlogDto
                {
                    
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var BlogList = _context.Blogs.Where(q => q.LanguageId == languageId)
                .Include(a=>a.Author)
                .Include(c=>c.CommentBlogs)
                .Include(q=>q.ItemCategoryBlogs)
                .ThenInclude(q=>q.CategoryBlog)
                .OrderByDescending(p => p.InsertTime).AsQueryable();
            if (!string.IsNullOrEmpty(requestGetBlog.SearchKey))
            {
                requestGetBlog.SearchKey = requestGetBlog.SearchKey.Replace("-", " ");
                BlogList = BlogList.Where(l => l.Title.Contains(requestGetBlog.SearchKey)||l.Description.Contains(requestGetBlog.SearchKey));
            }
            int RowsCount = 0;
            var Blogs =
             BlogList.Where(q => q.IsRemoved == false).Select(r => new GetAllBlogDto
            {
                Id = r.Id,
                Description= r.Description,
                Author=r.Author.Name,
                CategoryBlog=r.ItemCategoryBlogs.Select(y=>new CategoryBlogsListDto
                {
                    Id=y.Id,
                    Name=y.CategoryBlog.Name
                }).ToList(),
                Content=r.Content,
                Image=BaseUrl+r.Pic,
                IsActive=r.State,
                Title=r.Title,
                View=r.View,
                CommentCount=r.CommentBlogs.Count,
                Slug=r.Slug.Replace(" ","-")
            }).ToPaged(requestGetBlog.Page, requestGetBlog.PageSize, out RowsCount).ToList();
            return new ResultGetBlogDto
            {
                Blogs=Blogs,
                Rows=RowsCount,
                Pageinate = Pagination.PaginateAdmin(requestGetBlog.Page, requestGetBlog.PageSize, RowsCount, "blogs",requestGetBlog.SearchKey,requestGetBlog.Tag,requestGetBlog.Category),
            };
        }
    }
    public class CategoryBlogsListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class GetAllBlogDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public List<CategoryBlogsListDto> CategoryBlog { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public int View { get; set; }
        public int CommentCount { get; set; }
    }
    public class ResultGetBlogDto
    {
        public List<GetAllBlogDto> Blogs { get; set; }
        public long Rows;
        public string? Pageinate { get; set; }
    }
    public class RequestGetBlogDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchKey { get; set; }
        public string? Tag { get; set; }
        public string? Category { get; set; }

    }
}
