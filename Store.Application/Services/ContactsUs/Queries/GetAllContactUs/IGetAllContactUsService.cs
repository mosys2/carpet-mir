using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Common;
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
		public GetAllContactUsService(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<ResultGetContactUsDto> Execute(RequestGetContactUsDto requestGetContact)
		{

			var ContactUsList = _context.ContactUs.Include(q => q.Language)
						  .OrderByDescending(p => p.InsertTime).AsQueryable();
			if (!string.IsNullOrEmpty(requestGetContact.LanguegeId))
			{
				ContactUsList = ContactUsList.Where(l => l.LanguageId == requestGetContact.LanguegeId);
			}
            if (!string.IsNullOrEmpty(requestGetContact.SearchKey))
            {
                ContactUsList = ContactUsList.Where(l => l.Name.Contains(requestGetContact.SearchKey) || l.Email.Contains(requestGetContact.SearchKey));
            }
            int RowsCount = 0;
            var ContactUs =
			 ContactUsList.Where(q => q.IsRemoved == false).ToPaged(requestGetContact.Page, 20, out RowsCount).Select(r => new GetAllContactUsDto
			{
				Id = r.Id,
				Seen = r.Seen,
				LanguegeId = r.LanguageId,
				Name = r.Name,
				LanguegeName = r.Language.Name,
				InsertTime = r.InsertTime,
				Email=r.Email,
				Mobile=r.Mobile
			}).ToList();
			return new ResultGetContactUsDto()
			{
				ContactUs= ContactUs,
				Rows= RowsCount,
            };
		}
	}
	public class GetAllContactUsDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
        public string? Mobile { get; set; }
        public string LanguegeId { get; set; }
		public string LanguegeName { get; set; }
		public DateTime? InsertTime { get; set; }
		public bool Seen { get; set; }
      
    }
    public class ResultGetContactUsDto
    {
        public List<GetAllContactUsDto> ContactUs { get; set; }
        public long Rows;
    }
    public class RequestGetContactUsDto
    {
        public int Page { get; set; }
        public string? SearchKey { get; set; }
        public string LanguegeId { get; set; }

    }
}
