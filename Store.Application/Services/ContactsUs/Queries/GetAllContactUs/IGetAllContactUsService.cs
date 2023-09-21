using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Common;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ContactsUs.Queries.GetAllContactUs
{
	public interface IGetAllContactUsService
	{
	Task<ResultGetContactUsDto> Execute(RequestGetContactUsDto requestGetContact);
	}
	public class GetAllContactUsService : IGetAllContactUsService
	{
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllContactUsService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultGetContactUsDto> Execute(RequestGetContactUsDto requestGetContact)
		{
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultGetContactUsDto
                {
                    
                };
            }
            var ContactUsList = _context.ContactUs.Where(q => q.LanguageId == languageId)
                          .OrderByDescending(p => p.InsertTime).AsQueryable();
            if (!string.IsNullOrEmpty(requestGetContact.SearchKey))
            {
                ContactUsList = ContactUsList.Where(l => l.Name.Contains(requestGetContact.SearchKey) || l.Email.Contains(requestGetContact.SearchKey));
            }
            int RowsCount = 0;
            var ContactUs =
			 ContactUsList.Where(q => q.IsRemoved == false).Select(r => new GetAllContactUsDto
			{
				Id = r.Id,
				Seen = r.Seen,
				Name = r.Name,
				LanguegeName = r.Language.Name,
				InsertTime = Assistants.ConvertToShamsi(r.InsertTime.ToString()),
				Email=r.Email,
				Mobile=r.Mobile
			}).ToPaged(requestGetContact.Page, requestGetContact.PageSize, out RowsCount).ToList();
			return new ResultGetContactUsDto()
			{
				ContactUs= ContactUs,
				Rows= RowsCount,
                Pageinate = Pagination.PaginateAdmin(requestGetContact.Page, requestGetContact.PageSize, RowsCount, "contactus", requestGetContact.SearchKey, requestGetContact.Tag, requestGetContact.Category),
            };
		}
	}
	public class GetAllContactUsDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
        public string? Mobile { get; set; }
		public string LanguegeName { get; set; }
		public string? InsertTime { get; set; }
		public bool Seen { get; set; }
    }
    public class ResultGetContactUsDto
    {
        public List<GetAllContactUsDto> ContactUs { get; set; }
        public long Rows;
        public string? Pageinate { get; set; }
    }
    public class RequestGetContactUsDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchKey { get; set; }
        public string? Tag { get; set; }
        public string? Category { get; set; }

    }
}
