using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ProductsSite.Queries.GetEditProductsList;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetEditBlog
{
	public interface IGetEditBlogService
	{
		Task<ResultDto<GetEditBlogDto>> Execute(string BlogId);

	}
	public class GetEditBlogService : IGetEditBlogService
	{
		private readonly IDatabaseContext _context;
		public GetEditBlogService(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<ResultDto<GetEditBlogDto>> Execute(string BlogId)
		{
			var BlogList = _context.Blogs.Include(t => t.ItemCategoryBlogs).Include(w => w.BlogItemTags).AsQueryable();
			var Blog = await BlogList.Where(q => q.Id == BlogId).FirstOrDefaultAsync();
			if (Blog == null)
			{
				return new ResultDto<GetEditBlogDto>
				{
					IsSuccess = false,
					Message = MessageInUser.NotFind,
				};
			}
			return new ResultDto<GetEditBlogDto>
			{
				Data = new GetEditBlogDto
				{
					Id = Blog.Id,
					Author = Blog.AuthorId,
					CategoryBlog = Blog.ItemCategoryBlogs.Select(i => i.CategoryBlogId).ToArray(),
					Content = Blog.Content,
					Description = Blog.Description,
					Image = Blog.Pic,
					IsActive = Blog.State,
					Keywords = Blog.Keywords,
					LanguegeId = Blog.LanguageId,
					MetaTag = Blog.MetaTag,
					MinPic = Blog.MinPic,
					ShowWriter = Blog.WriterShow,
					Slug = Blog.Slug,
					TagBlog = Blog.BlogItemTags.Select(j => j.BlogTagId).ToArray(),
					Title = Blog.Title,
				},
				IsSuccess=true
			};
		}
	}
	public class GetEditBlogDto
	{
		[Required]
		public string Id { get; set; }
		public string? Title { get; set; }
		public string? Content { get; set; }
		public string? Description { get; set; }
		[Required]
		public string Author { get; set; }
		public string? Image { get; set; }
		public string? MinPic { get; set; }
		public string? MetaTag { get; set; }
		public string? Keywords { get; set; }
		public string? Slug { get; set; }
		[Required]
		public string LanguegeId { get; set; }
		[Required]
		public string[] CategoryBlog { get; set; }
		public string[]? TagBlog { get; set; }
		public bool IsActive { get; set; }
		public bool ShowWriter { get; set; }
	}
}
