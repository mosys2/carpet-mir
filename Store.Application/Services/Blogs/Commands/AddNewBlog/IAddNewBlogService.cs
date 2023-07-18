using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
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
        public AddNewBlogService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(RequestBlogDto requestBlog)
        {
            var user = _context.Users.Find(requestBlog.UserId);
            if (user == null)
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
                User = user,
                LanguageId=requestBlog.LanguegeId,
                ImageSrc = requestBlog.Image,
                Key = requestBlog.Key,
                InsertTime = DateTime.Now,
                ShowAt=requestBlog.ShowAt,
                State = requestBlog.State,
                Text = requestBlog.Text,
                Title = requestBlog.Title,
                View =0,
            };
            await  _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            //Find Item CategoryBlog
            if (requestBlog.CategoryBlogId != null)
            {
                List<ItemCategoryBlog> itemCategoryBlog = new List<ItemCategoryBlog>();

                foreach (var id in requestBlog.CategoryBlogId)
                {
                    var CategoryBlogs = _context.CategoryBlogs.Find(id);
                    itemCategoryBlog.Add(new ItemCategoryBlog
                    {
                        Id = Guid.NewGuid().ToString(),
                        Blog = blog,
                        BlogId = CategoryBlogs.Id,
                        CategoryBlog = CategoryBlogs,
                        CategoryBlogId = CategoryBlogs.Id,
                        InsertTime = DateTime.Now
                    });
                }
                //Add ItemCategoryBlog
               blog.ItemCategoryBlogs = itemCategoryBlog;
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
        public string LanguegeId { get; set; }
        public string Title { get; set; }
        public int View { get; set; }
        public bool State { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public string Key { get; set; }
        public string Image { get; set; }
        public DateTime ShowAt { get; set; }
        public string[]? CategoryBlogId { get; set; }
    }
}
