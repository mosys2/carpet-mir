using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Products.Commands.AddNewBrand;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Blogs;
using Store.Domain.Entities.Products;
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
        public AddNewBlogTagService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(BlogTagDto blog)
        {
            var languege = await _context.Languages.FindAsync(blog.LanguegeId);
            if (languege == null)
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
                LanguageId=blog.LanguegeId,
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
        public string  LanguegeId { get; set; }
    }
}
