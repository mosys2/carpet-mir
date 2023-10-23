using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllComments;
using Store.Application.Services.Langueges.Queries;
using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetMoreCommentsBlog
{
    public interface IGetMoreCommentsBlogService
    {
        Task<List<GetMoreCommentsDto>> Execute(RequestMoreCommentsDto requestMore);
    }
    public class GetMoreCommentsService : IGetMoreCommentsBlogService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetMoreCommentsService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<List<GetMoreCommentsDto>> Execute(RequestMoreCommentsDto requestMore)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetMoreCommentsDto>
                {

                };
            }
            var BlogList = _context.Blogs.Where(q => q.LanguageId == languageId && q.Id == requestMore.Id)
                .Include(c => c.CommentBlogs)
                .OrderByDescending(p => p.InsertTime).AsQueryable();
            var commentsList = await BlogList.SelectMany(e => e.CommentBlogs.Select(comment => new GetMoreCommentsDto
            {
                Id = comment.Id,
                Name = comment.Name,
                Text = comment.Content,
                Approved=comment.Approved,
                InsertTime = Assistants.ConvertToShamsi(comment.InsertTime.Value.ToString())
            })).Skip(requestMore.StartIndex).Take(requestMore.Count).ToListAsync();
            return commentsList;
        }
    }
    public class GetMoreCommentsDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public bool Approved { get; set; }
        public string? InsertTime { get; set; }
    }
    public class RequestMoreCommentsDto
    {
        public string Id { get; set; }
        public int StartIndex { get; set; }
        public int Count { get; set; }
    }
}
