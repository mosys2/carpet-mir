using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Authors.Queries.GetAllAuthor
{
    public interface IGetAllAuthorService
    {
        Task<ResultDto<List<GetAllAuthorDto>>> Execute(string? LanguegeId);
    }
    public class GetAllAuthorService : IGetAllAuthorService
    {
        private readonly IDatabaseContext _context;
        public GetAllAuthorService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<GetAllAuthorDto>>> Execute(string? LanguegeId)
        {
            var AuthorList = _context.Authors.Include(q => q.Language)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            if (!string.IsNullOrEmpty(LanguegeId))
            {
                AuthorList = AuthorList.Where(l => l.LanguageId == LanguegeId);
            }
            var Athors =
            await AuthorList.Where(q => q.IsRemoved == false).Select(r => new GetAllAuthorDto
            {
               Id=r.Id,
               IsActive=r.IsActive,
               LanguegeId=r.LanguageId,
               Name=r.Name,
               LanguegeName=r.Language.Name,
               InsertTime=r.InsertTime
            }).ToListAsync();
            return new ResultDto<List<GetAllAuthorDto>>()
            {
                Data = Athors,
                IsSuccess = true
            };
        }
    }
    public class GetAllAuthorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LanguegeId { get; set; }
        public string LanguegeName { get; set; }
        public DateTime? InsertTime { get; set; }
        public bool IsActive { get; set; }
    }
}
