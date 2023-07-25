using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Products.Commands.AddNewBrand;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Blogs;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Application.Services.Blogs.Commands.AddNewBlogTag
{
    public interface IAddNewBlogTagService
    {
        Task<ResultDto> Execute(BlogTagDto blog);
    }
    public class AddNewBlogTagService : IAddNewBlogTagService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public AddNewBlogTagService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(BlogTagDto blog)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (languageId == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind,
                };
            }
            var cheackTag =await _context.BlogTags.Where(n => n.Name == blog.Name).FirstOrDefaultAsync();
            if (cheackTag != null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.ExistTag
                };
            }
            BlogTag blogTag = new BlogTag()
            {

                Id = Guid.NewGuid().ToString(),
                Name = blog.Name,
                InsertTime = DateTime.Now,
                LanguageId=languageId,
            };
            await _context.BlogTags.AddAsync(blogTag);
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "موفق"
            };
        }
    }
    public class BlogTagDto
    {
        public string Name { get; set; }
    }
}
