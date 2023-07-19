using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Results.Commands.RemoveResult;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Commands.RemoveCategoryBlog
{
    public interface IRemoveCategoryBlogService
    {
        Task<ResultDto> Execute(string IdCategoryBlog);
    }
    public class RemoveCategoryBlogService : IRemoveCategoryBlogService
    {
        private readonly IDatabaseContext _context;
        public RemoveCategoryBlogService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdCategoryBlog)
        {

            var category = await _context.CategoryBlogs.FindAsync(IdCategoryBlog);
            if (category == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نتیجه ایی یافت نشد!"
                };
            }
            category.IsRemoved = true;
            category.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.Delete
            };
        }
    }
}
