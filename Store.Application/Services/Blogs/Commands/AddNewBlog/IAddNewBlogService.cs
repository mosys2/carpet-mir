using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Blogs;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Commands.AddNewBlog
{
    public interface IAddNewBlogService
    {
        Task<ResultDto> Execute(RequestBlogDto requestBlog);
    }
    public class AddNewBlogService : IAddNewBlogService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public AddNewBlogService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(RequestBlogDto requestBlog)
        {
            var user =await _context.Users.FindAsync(requestBlog.UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageNotFind
                };
            }
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.MessageNotFind
                };
            }
            Blog blog = new Blog()
            {
                Id=Guid.NewGuid().ToString(),
                UserId = user.Id,
                LanguageId= languageId,
                Pic = requestBlog.Image,
                MinPic=requestBlog.MinPic,
                Keywords = requestBlog.KeyWords,
                InsertTime = DateTime.Now,
                ShowAt=requestBlog.ShowAt,
                State = requestBlog.State,
                Content = requestBlog.Content,
                Description=requestBlog.Description,
                AuthorId=requestBlog.AuthorId,
                MetaTag=requestBlog.MetaTag,
                Slug=requestBlog.Slug,
                WriterShow=requestBlog.WriterShow,
                Title = requestBlog.Title,
                View =0,
            };
            
                await _context.Blogs.AddAsync(blog);
                await _context.SaveChangesAsync();
            //Find Item CategoryBlog
            if (requestBlog.CategoryBlogId != null)
            {
                List<ItemCategoryBlog> itemCategoryBlog = new List<ItemCategoryBlog>();
                foreach (var id in requestBlog.CategoryBlogId)
                {
                    var CategoryBlogs =await _context.CategoryBlogs.FindAsync(id);
                    itemCategoryBlog.Add(new ItemCategoryBlog
                    {
                        Id = Guid.NewGuid().ToString(),
                        Blog = blog,
                        BlogId = blog.Id,
                        CategoryBlog = CategoryBlogs,
                        CategoryBlogId = CategoryBlogs.Id,
                        InsertTime = DateTime.Now
                    });
                }
                //Add ItemCategoryBlog
               blog.ItemCategoryBlogs = itemCategoryBlog;
              await _context.SaveChangesAsync();
            }
            //Find Item BlogTag
            if (requestBlog.BlogTags != null)
            {
                List<BlogItemTag> itemBlogTags = new List<BlogItemTag>();

                foreach (var id in requestBlog.BlogTags)
                {
                    var BlogTags =await _context.BlogTags.FindAsync(id);
                    itemBlogTags.Add(new BlogItemTag
                    {
                        Id = Guid.NewGuid().ToString(),
                        Blog = blog,
                        BlogId = blog.Id,
                        BlogTag = BlogTags,
                        BlogTagId = BlogTags.Id,
                        InsertTime = DateTime.Now
                    });
                }
                //Add ItemBlogTags
                blog.BlogItemTags = itemBlogTags;
                await _context.SaveChangesAsync();
            }
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class RequestBlogDto
    {
        public string Title { get; set; }
        public int View { get; set; }
        public bool State { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string KeyWords { get; set; }
        public string? Image { get; set; }
		public string? MinPic { get; set; }
		public string? Description { get; set; }
        public bool WriterShow { get; set; }
        public DateTime ShowAt { get; set; }
        public string[] CategoryBlogId { get; set; }
        public string[]? BlogTags { get; set; }
        public string AuthorId { get; set; }
        public string? MetaTag { get; set; }
		public string? Slug { get; set; }
	}
}
