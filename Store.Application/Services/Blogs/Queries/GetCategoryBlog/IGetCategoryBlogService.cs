using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetCategoryBlog
{
    public interface IGetCategoryBlogService
    {
        Task<ResultDto<List<GetCategoryBlogDto>>> Execute(string? languegeId);
    }
    public class GetCategoryBlogService : IGetCategoryBlogService
    {

        private readonly IDatabaseContext _context;
        public GetCategoryBlogService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task <ResultDto<List<GetCategoryBlogDto>>> Execute(string? languegeId)
        {
            var categoryBlogList = _context.CategoryBlogs.Include(q => q.Language)
                .OrderByDescending(p => p.InsertTime).AsQueryable();
            if (!string.IsNullOrEmpty(languegeId))
            {
                categoryBlogList = categoryBlogList.Where(l => l.LanguageId == languegeId);
            }
            var categoryBlogs =
            await categoryBlogList.Where(q=>q.IsRemoved==false).Select(r => new GetCategoryBlogDto
            {
                Id = r.Id,
                IsActive = r.IsActive,
                LanguegeId = r.LanguageId,
                LanguegeName = r.Language.Name,
                InsertTime = r.InsertTime,
                Name = r.Name,
                Slug = r.Slug,
                Description = r.Description
            }).ToListAsync();
            return new ResultDto<List<GetCategoryBlogDto>>()
            {
                Data = categoryBlogs,
                IsSuccess = true
            };
        }
    }
    public class GetCategoryBlogDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public string LanguegeId { get; set; }
        public string? Description { get; set; }
        public string LanguegeName { get; set; }
        public DateTime? InsertTime { get; set; }
        public bool IsActive { get; set; }
    }
}
