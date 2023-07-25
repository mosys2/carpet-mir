using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Commands.AddNewCategoryBlog
{
    public interface IAddNewCategoryBlogService
    {
        Task<ResultDto> Execute(RequestCategoryBlogDto requestCategory);
    }
    public class AddNewCategoryBlogService : IAddNewCategoryBlogService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public AddNewCategoryBlogService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(RequestCategoryBlogDto requestCategory)
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
            if(requestCategory.Id!=null)
            {
                var editCategory =await _context.CategoryBlogs.FindAsync(requestCategory.Id);
                editCategory.Name=requestCategory.Name;
                editCategory.Description=requestCategory.Description;
                editCategory.LanguageId=languageId;
                editCategory.Slug=requestCategory.Slug;
                editCategory.IsActive=requestCategory.IsActive;
                editCategory.UpdateTime = DateTime.Now;
               await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "موفق"
                };
            }
            CategoryBlog categoryBlog = new CategoryBlog()
            {
                Id=Guid.NewGuid().ToString(),
                Name=requestCategory.Name,
                IsActive=requestCategory.IsActive,
                Description=requestCategory.Description,
                Slug=requestCategory.Slug,
                LanguageId=languageId,
                InsertTime=DateTime.Now
            };
            try
            {
               await _context.CategoryBlogs.AddAsync(categoryBlog);
                await _context.SaveChangesAsync();

            }
            catch
            {

            }
            
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class RequestCategoryBlogDto
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public bool IsActive { get; set; }
    }
}
