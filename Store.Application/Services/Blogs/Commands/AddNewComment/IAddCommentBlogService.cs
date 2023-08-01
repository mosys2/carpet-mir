using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetDetailBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Commands.AddNewComment
{
    public interface IAddCommentBlogService
    {
        Task<ResultDto> Execute(CommentBlogDto request);
    }
    public class AddCommentBlogService : IAddCommentBlogService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public AddCommentBlogService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(CommentBlogDto request)
        {
            try
            {
                string languageId = _language.Execute().Result.Data.Id ?? "";
                if (string.IsNullOrEmpty(languageId))
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = MessageInUser.NotFoundEn
                    };
                }

                var blog = await _context.Blogs.FindAsync(request.BlogId);
                if (blog == null)
                {
                    return new ResultDto
                    {
                        IsSuccess=false,
                        Message=MessageInUser.NotFoundEn
                    };
                }

                CommentBlog comment = new CommentBlog()
                {
                    Id=Guid.NewGuid().ToString(),
                    BlogId = blog.Id,
                    Approved=false,
                    Name=request.Name,
                    Content=request.Content,
                    Email=request.Email,
                    InsertTime=DateTime.Now,
                    LanguageId=languageId,
                    ParentCommentId=request.ParentCommentId,
                    Seen=false
                };
                await _context.CommentBlogs.AddAsync(comment);
                await _context.SaveChangesAsync();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = MessageInUser.RegisterSuccessEn
                };
            }catch(Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess=false,
                    Message=ex.Message
                };
            }
        }
    }
    public class CommentBlogDto
    {

        public string BlogId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]  
        public string Email { get; set; }
        public string? Website { get; set; }
        [Required]
        public string Content { get; set; }
        public string? ParentCommentId { get ; set; }
    }
}
