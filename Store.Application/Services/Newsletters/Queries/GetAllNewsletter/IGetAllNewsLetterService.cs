using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Menu.Queries.IGetMenu;
using Store.Common;
using Store.Common.Dto;
using Store.Domain.Entities.Newsletters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Newsletters.Queries.GetAllNewsletter
{
    public interface IGetAllNewsLetterService
    {
        Task<ResultDto<ResultNewsletterDto>> Execute(int page, int pagesize,string searchkey);
    }
    public class GetAllNewsLetterService : IGetAllNewsLetterService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetAllNewsLetterService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }

        public async Task<ResultDto<ResultNewsletterDto>> Execute(int page, int pagesize, string searchkey)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<ResultNewsletterDto>
                {
                    IsSuccess=false
                };
            }
            int totalRow = 0;
            var result = _context.Newsletters.Where(p => p.LanguageId==languageId).ToPaged(page, pagesize, out totalRow).ToList();
            return new ResultDto<ResultNewsletterDto>
            {
                IsSuccess = true,
                Data=new ResultNewsletterDto
                {
                    Newsletters=result,
                    TotalRow=totalRow,
                    Paginate=Pagination.PaginateAdmin(page, pagesize, totalRow, "newsletter", searchkey)
                }
            };
        }
    }
    public class RequestGetNewsletterDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchKey { get; set; }

    }
    public class ResultNewsletterDto
    {
        public List<Newsletter> Newsletters { get; set; }
        public int TotalRow { get; set; }
        public string? Paginate { get; set; }

    }
}
