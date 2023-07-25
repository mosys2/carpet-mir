using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Langueges.Queries;
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
        Task<ResultDto<List<AllCategoryBlogDto>>> Execute();
    }
    public class GetAllCategoryBlogService:IGetAllCategoryBlogService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetAllCategoryBlogService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }

        public async Task<ResultDto<List<AllCategoryBlogDto>>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<List<AllCategoryBlogDto>>
                {
                    IsSuccess=false,
                };
            }

            var allCategoryBlog = _context.CategoryBlogs.Where(q => q.LanguageId == languageId)
                .OrderByDescending(e => e.InsertTime).AsQueryable();
           
            var listCategorBlog =await allCategoryBlog.Select(r => new AllCategoryBlogDto
            {
                Id = r.Id,
                InsertTime = r.InsertTime,
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
        public DateTime? InsertTime { get; set; }
    }
}
