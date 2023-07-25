using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetEditProductsList;
using Store.Application.Services.Users.Queries.Edit;
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

namespace Store.Application.Services.Blogs.Commands.EditBlog
{
	public interface IEditBlogService
	{
		Task<ResultDto> Execute(EditBlogDto EditBlog);
	}
	public class EditBlogService : IEditBlogService
	{
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public EditBlogService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(EditBlogDto EditBlog)
		{
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageNotFind
                };
            }
            var blog = await _context.Blogs.FindAsync(EditBlog.Id);
			if (blog == null)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				};
			}
			var author = await _context.Authors.FindAsync(EditBlog.AuthorId);
			var user = await _context.Users.FindAsync(EditBlog.UserId);
			var slug = _context.Blogs.Where(s => s.Slug == EditBlog.Slug && s.Slug != blog.Slug).ToList();
			if (user == null) { return new ResultDto { IsSuccess = false, Message =MessageInUser.NotExistsUser }; }
			if (slug.Any()) { return new ResultDto { IsSuccess = false, Message =MessageInUser.ChangeSlug }; }
			if (author==null) { return new ResultDto { IsSuccess = false, Message = MessageInUser.NotExistsAuthor }; }
			if(EditBlog.CategoryBlog==null) { return new ResultDto { IsSuccess = false, Message = MessageInUser.NotExistsCategoryBlog };}
			//Edit Blog
			blog.Title = EditBlog.Title; 
			blog.Description=EditBlog.Description;
			blog.Content = EditBlog.Content;
			blog.Pic = EditBlog.Image;
			blog.MinPic=EditBlog.MinPic;
			blog.Keywords = EditBlog.Keywords;
			blog.MetaTag=EditBlog.MetaTag;
			blog.Slug=EditBlog.Slug;
			blog.State = EditBlog.IsActive;
			blog.WriterShow = EditBlog.ShowWriter;
			//Remove List ItemTagBlog
			var listItemTagsBlogRemove = _context.BlogItemTags.Where(r => r.BlogId == EditBlog.Id).ToList();
			_context.BlogItemTags.RemoveRange(listItemTagsBlogRemove);
			await _context.SaveChangesAsync();
			//Edit Item Tag Blog
			if (EditBlog.BlogTags != null)
			{
				List<BlogItemTag> itemTagsBlog = new List<BlogItemTag>();

				foreach (var id in EditBlog.BlogTags)
				{
					var TagsBlog = await _context.BlogTags.FindAsync(id);
					itemTagsBlog.Add(new BlogItemTag
					{
						Id = Guid.NewGuid().ToString(),
						Blog = blog,
						BlogId = blog.Id,
						BlogTag = TagsBlog,
						BlogTagId = TagsBlog.Id,
						InsertTime = DateTime.Now,
						UpdateTime = DateTime.Now
					});
				}
				//Edit Item Tag Blog
				blog.BlogItemTags = itemTagsBlog;
				await _context.SaveChangesAsync();
			}
			//Remove List CategoryBlog
			var listItemCategoryBlogRemove = _context.ItemCategoryBlogs.Where(r => r.BlogId == EditBlog.Id).ToList();
			_context.ItemCategoryBlogs.RemoveRange(listItemCategoryBlogRemove);
			await _context.SaveChangesAsync();
			List<ItemCategoryBlog> itemCategoryBlog = new List<ItemCategoryBlog>();

			foreach (var id in EditBlog.CategoryBlog)
			{
				var CategoryBlog = await _context.CategoryBlogs.FindAsync(id);
				itemCategoryBlog.Add(new ItemCategoryBlog
				{
					Id = Guid.NewGuid().ToString(),
					Blog = blog,
					BlogId = blog.Id,
					CategoryBlog = CategoryBlog,
					CategoryBlogId = CategoryBlog.Id,
					InsertTime = DateTime.Now,
					UpdateTime = DateTime.Now
				});
			}
			//Edit Item Category Blog
			blog.ItemCategoryBlogs = itemCategoryBlog;
			await _context.SaveChangesAsync();
			return new ResultDto()
			{
				IsSuccess = true,
				Message = MessageInUser.MessageEditBlog
			};
		}
	}
	public class EditBlogDto
	{
		[Required]
		public string Id { get; set; }
		public string Title { get; set; }
		public string? Content { get; set; }
		public string? Description { get; set; }
		[Required]
		public string AuthorId { get; set; }
		public string? Image { get; set; }
		public string? MinPic { get; set; }
		public string? MetaTag { get; set; }
		public string? Keywords { get; set; }
		public string? Slug { get; set; }
		//[Required]
		public string? UserId { get; set; }
		[Required]
		public string[] CategoryBlog { get; set; }
		public string[]? BlogTags { get; set; }
		public bool IsActive { get; set; }
		public bool ShowWriter { get; set; }
	}

}
