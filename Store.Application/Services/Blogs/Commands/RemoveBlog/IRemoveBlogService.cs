using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Commands.RemoveBlog
{
	public interface IRemoveBlogService
	{
		Task<ResultDto> Execute(string idBlog);
	}
	public class RemoveBlogService : IRemoveBlogService
	{
		private readonly IDatabaseContext _context;
		public RemoveBlogService(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<ResultDto> Execute(string idBlog)
		{
			var deleteBlog = await _context.Blogs.FindAsync(idBlog);
			if (deleteBlog == null)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = MessageInUser.MessageInvalidOperation
				};
			}
			//Item Tags Blog
			var TagsBlog =  _context.BlogItemTags.Where(t => t.BlogId == idBlog).ToList();
			if (TagsBlog.Any())
			{
				_context.BlogItemTags.RemoveRange(TagsBlog);
				await _context.SaveChangesAsync();
			}
			//Item Category Blog
			var CategoryBlog = _context.ItemCategoryBlogs.Where(t => t.BlogId == idBlog).ToList();
			if (CategoryBlog.Any())
			{
				_context.ItemCategoryBlogs.RemoveRange(CategoryBlog);
				await _context.SaveChangesAsync();
			}
			//Remove Logical
			deleteBlog.RemoveTime = DateTime.Now;
			deleteBlog.IsRemoved = true;
			await _context.SaveChangesAsync();
			//Show Result
			return new ResultDto()
			{
				IsSuccess = true,
				Message = MessageInUser.RemoveBlog
			};
		}
	}
}
