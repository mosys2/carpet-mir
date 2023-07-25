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

namespace Store.Application.Services.Blogs.Queries.GetCategoryBlog
{
    public interface IGetCategoryBlogService
    {
        Task<ResultDto<List<GetCategoryBlogDto>>> Execute();
    }
    public class GetCategoryBlogService : IGetCategoryBlogService
    {

        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetCategoryBlogService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }

        public async Task <ResultDto<List<GetCategoryBlogDto>>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<List<GetCategoryBlogDto>>
                {
                    IsSuccess = false,
                };
            }
            var categoryBlogList = _context.CategoryBlogs.Where(q => q.LanguageId == languageId)
                .OrderByDescending(p => p.InsertTime).AsQueryable();
            
            var categoryBlogs =
            await categoryBlogList.Where(q=>q.IsRemoved==false).Select(r => new GetCategoryBlogDto
            {
                Id = r.Id,
                IsActive = r.IsActive,
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
        public string? Description { get; set; }
        public string LanguegeName { get; set; }
        public DateTime? InsertTime { get; set; }
        public bool IsActive { get; set; }
    }
}
