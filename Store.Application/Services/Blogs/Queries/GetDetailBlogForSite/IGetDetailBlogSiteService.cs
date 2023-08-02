using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Blogs;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Application.Services.Blogs.Queries.GetDetailBlogForSite
{
    public interface IGetDetailBlogSiteService
    {
        Task<ResultDto<GetDetailBlogSiteDto>> Execute(string Id);
    }
    public class GetDetailBlogSiteService : IGetDetailBlogSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetDetailBlogSiteService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _language = languege;
        }
        public static List<CommentsForBlogDto> Comments = new List<CommentsForBlogDto>();
        public static List<CommentsForBlogDto> Replies = new List<CommentsForBlogDto>();
        public async Task<ResultDto<GetDetailBlogSiteDto>> Execute(string Id)
        {
            Comments.Clear();
            Replies.Clear();
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<GetDetailBlogSiteDto>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var FindBlog = _context.Blogs.Include(s => s.Author).Include(i => i.ItemCategoryBlogs).ThenInclude(d=>d.CategoryBlog)
                .Include(m => m.BlogItemTags).ThenInclude(p=>p.BlogTag)
                .Where(p => p.LanguageId == languageId && p.Id == Id).FirstOrDefault();
            if (FindBlog == null)
            {
                return new ResultDto<GetDetailBlogSiteDto>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            //Add Visit
            FindBlog.View++;
            await _context.SaveChangesAsync();
            //GetComments Blog
            var ListComments =await _context.CommentBlogs
           .Where(c => c.BlogId == FindBlog.Id && c.LanguageId == languageId&&c.Approved)
           .OrderByDescending(e => e.InsertTime)
           .Select(r => new CommentsForBlogDto {
               InsertTime = r.InsertTime.Value.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
               Name = r.Name,
               Text = r.Content,
               ParentId=r.ParentCommentId,
               Id=r.Id
           }).ToListAsync();

            Comments.AddRange(ListComments);
            foreach (var item in ListComments.Where(e => e.ParentId == null))
            {
                int level = 1;
                var child = ListComments.Where(y => y.ParentId == item.Id).ToList();
                listGenerator(child, level);
            }
            //
            return new ResultDto<GetDetailBlogSiteDto>
            {
                Data = new GetDetailBlogSiteDto
                {
                    Author = FindBlog.Author.Name,
                    AuthorDescription=FindBlog.Author.Description,
                    Category = FindBlog.ItemCategoryBlogs.Select(w => new BlogCategoryDto
                    {
                        Id = w.CategoryBlog.Id,
                        Name = w.CategoryBlog.Name,

                    }).ToList(),
                    Tags = FindBlog.BlogItemTags.Select(r => new BlogTagDto
                    {
                        Id = r.BlogTag.Id,
                        Name = r.BlogTag.Name,
                    }).ToList(),
                    Id=FindBlog.Id,
                    Content = FindBlog.Content,
                    Description = FindBlog.Description,
                    Image = BaseUrl + FindBlog.Pic,
                    InsertTime = FindBlog.InsertTime.Value.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
                    Title = FindBlog.Title,
                    Comments=Comments,
                    Replies=Replies,
                    CommentCount=ListComments.Count,
                }
            };
        }
        public void listGenerator(List<CommentsForBlogDto> selectList, int level)
        {
            level++;
            foreach (var itemChild in selectList)
            {
                var childN = Comments.Where(p => p.ParentId == itemChild.Id).ToList();
                if (childN.Any())
                {
                    Replies.Add(new CommentsForBlogDto()
                    {
                        Id = itemChild.Id,
                        Name = itemChild.Name,
                        ParentId = itemChild.ParentId,
                        InsertTime=itemChild.InsertTime,
                        Text=itemChild.Text,
                    });
                    listGenerator(childN, level);
                }
                else
                {
                    Replies.Add(new CommentsForBlogDto()
                    {
                        Id = itemChild.Id,
                        Name = itemChild.Name,
                        ParentId = itemChild.ParentId,
                        InsertTime=itemChild.InsertTime,
                        Text=itemChild.Text,
                    });
                }
            }
            return;
        }
    }
    public class BlogTagDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
    public class BlogCategoryDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
    public class GetDetailBlogSiteDto
    {
        public string? Id { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? AuthorDescription { get; set; }

        public string? InsertTime { get; set; }
        public List<BlogCategoryDto>? Category { get; set; }
        public List<BlogTagDto>? Tags { get; set; }
        public List<CommentsForBlogDto> Comments { get; set; }
        public List<CommentsForBlogDto> Replies { get; set; }
        public int CommentCount { get; set; }
        public string? Content { get; set; }
    }
    public class CommentsForBlogDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public string? InsertTime { get; set; }
        public string? ParentId { get; set; }
    }
}
