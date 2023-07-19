using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetAllCategoryBlog
{
    public interface IGetAllCategoryBlogService
    {
        Task<ResultDto<List<AllCategoryBlogDto>>> Execute(string? languegeId);
    }
    public class GetAllCategoryBlogService:IGetAllCategoryBlogService
    {
        private readonly IDatabaseContext _context;
        public GetAllCategoryBlogService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<List<AllCategoryBlogDto>>> Execute(string? languegeId)
        {
            var allCategoryBlog = _context.CategoryBlogs
                .OrderByDescending(e => e.InsertTime).AsQueryable();
            if(!string.IsNullOrEmpty(languegeId))
            {
                allCategoryBlog = allCategoryBlog.Where(l=>l.LanguageId==languegeId);
            }
            var listCategorBlog =await allCategoryBlog.Select(r => new AllCategoryBlogDto
            {
                Id = r.Id,
                InsertTime = r.InsertTime,
                LanguegeId = r.LanguageId,
                Name = r.Name,

            }).ToListAsync();
            return new ResultDto<List<AllCategoryBlogDto>>()
            {
                Data=listCategorBlog,
                IsSuccess=true
            };
        }
    }
    public class AllCategoryBlogDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LanguegeId { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
