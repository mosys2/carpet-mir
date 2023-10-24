using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetAllComments
{
    public interface IGetAllCommentsService
    {
        Task<List<GetAllCommentsDto>> Execute(RequestCommentsDto requestComments);
    }
    public class GetAllCommentsService : IGetAllCommentsService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetAllCommentsService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<List<GetAllCommentsDto>> Execute(RequestCommentsDto requestComments)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetAllCommentsDto>
                {

                };
            }
            var BlogList = _context.Blogs.Where(q => q.LanguageId == languageId&&q.Id==requestComments.Id)
                .Include(c => c.CommentBlogs)
                .OrderByDescending(p => p.InsertTime).AsQueryable();
            //if (requestComments.StartIndex > 0 || requestComments.Count > 0)
            //{
            //    BlogList = BlogList
            //       .Skip(requestComments.StartIndex)
            //      .Take(requestComments.Count);
            //}
            var commentsList =await  BlogList.SelectMany(e => e.CommentBlogs.Select(comment => new GetAllCommentsDto
            {
                Id = comment.Id,
                Name = comment.Name,
                Text = comment.Content,
                Approved=comment.Approved,
                InsertTime = Assistants.ConvertToShamsi(comment.InsertTime.Value.ToString())
            })).Take(1).ToListAsync();
            return commentsList;
        }
    }
    public class GetAllCommentsDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public bool Approved { get; set; }
        public  string? InsertTime { get; set; }
    }
    public class RequestCommentsDto
    {
        public string Id { get; set; }
        //public int StartIndex { get; set; }
        //public int Count { get; set; }
    }
}
