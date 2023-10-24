using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetMoreCommentsBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Commands.ChangeStatusComment
{
    public interface IChangeStatusCommentService
    {
        Task<ResultDto> Execute(string commentId, bool isConfirmed);
    }
    public class ChangeStatusCommentService : IChangeStatusCommentService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public ChangeStatusCommentService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(string commentId, bool isConfirmed)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess=false,
                    Message=MessageInUser.LanguageNotFound
                };
            }
            var comment=_context.CommentBlogs.Where(i=>i.LanguageId==languageId&&i.Id==commentId).FirstOrDefault();
            if (comment==null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            comment.Approved = isConfirmed;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
}
