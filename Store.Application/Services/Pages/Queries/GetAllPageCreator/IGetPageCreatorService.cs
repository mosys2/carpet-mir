using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Pages.Queries.GetAllPageCreator
{
    public interface IGetPageCreatorService
    {
        Task<ResultGetPageCreatorDto> Execute(RequestGetPageCreatorDto requestGetPage);
    }
    public class GetPageCreatorService : IGetPageCreatorService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;

        public GetPageCreatorService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ResultGetPageCreatorDto> Execute(RequestGetPageCreatorDto requestGetPage)
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var PagesList = _context.PageCreators.OrderByDescending(w => w.InsertTime).AsQueryable();
            if (!string.IsNullOrEmpty(requestGetPage.LanguegeId))
            {
                PagesList = PagesList.Where(l => l.LanguageId == requestGetPage.LanguegeId);
            }
            if (!string.IsNullOrEmpty(requestGetPage.SearchKey))
            {
                PagesList = PagesList.Where(l => l.Title.Contains(requestGetPage.SearchKey) || l.Description.Contains(requestGetPage.SearchKey));
            }
            int RowsCount = 0;
            var Pages =
             PagesList.Where(q => q.IsRemoved == false).ToPaged(requestGetPage.Page, 20, out RowsCount).Select(r => new GetAllPageCreatorDto
             {
                Id=r.Id,
                IsActive=r.IsActive,
                Title=r.Title,
                Url=BaseUrl+"/Pages/"+(string.IsNullOrEmpty(r.Slug)?r.Id:r.Slug),
             }).ToList();
            return new ResultGetPageCreatorDto
            {
                PageCreators = Pages,
                Rows = RowsCount
            };
        }
    }
    public class GetAllPageCreatorDto
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public bool IsActive { get; set; }
    }
    public class ResultGetPageCreatorDto
    {
        public List<GetAllPageCreatorDto> PageCreators { get; set; }
        public long Rows;
    }
    public class RequestGetPageCreatorDto
    {
        public int Page { get; set; }
        public string? SearchKey { get; set; }
        public string LanguegeId { get; set; }
    }
}
