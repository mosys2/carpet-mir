using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
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
        Task <ResultDto<List<ListBlogTagDto>>> Execute(string? LanguegeId);
    }
    public class GetListBlogTagService : IGetListBlogTagService
    {
        private readonly IDatabaseContext _context;
        public GetListBlogTagService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<ListBlogTagDto>>> Execute(string? LanguegeId)
        {
            var tagBlogs = _context.BlogTags.Include(q => q.Language)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            if (!string.IsNullOrEmpty(LanguegeId))
            {
                tagBlogs = tagBlogs.Where(l => l.LanguageId == LanguegeId);
            }
            var tagBlogList =
            await tagBlogs.Where(q => q.IsRemoved == false).Select(r => new ListBlogTagDto
            {
                Id = r.Id,
                LanguegeId = r.LanguageId,
                Name = r.Name,
            }).ToListAsync();
            return new ResultDto<List<ListBlogTagDto>>()
            {
            Data= tagBlogList,
            IsSuccess= true
            };
        }
    }
    public class ListBlogTagDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LanguegeId { get; set; }
    }
}
