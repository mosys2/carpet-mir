using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
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
        Task<ResultDto<List<GetAllAuthorDto>>> Execute();
    }
    public class GetAllAuthorService : IGetAllAuthorService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllAuthorService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto<List<GetAllAuthorDto>>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<List<GetAllAuthorDto>>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            var AuthorList = _context.Authors.Where(q => q.LanguageId == languageId)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            var Athors =
            await AuthorList.Where(q => q.IsRemoved == false).Select(r => new GetAllAuthorDto
            {
               Id=r.Id,
               IsActive=r.IsActive,
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
        public string LanguegeName { get; set; }
        public DateTime? InsertTime { get; set; }
        public bool IsActive { get; set; }
    }
}
