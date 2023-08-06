using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using Store.Common;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetAllBlogForSite
{
    public interface IGetAllBlogSiteService
    {
        Task<ResultDto<ResultBlogsForSiteDto>> Execute(string SearchKey, int page, int pagesize);
    }
    public class GetAllBlogSiteService : IGetAllBlogSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetAllBlogSiteService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _language = languege;
        }
        public async Task<ResultDto<ResultBlogsForSiteDto>> Execute(string SearchKey, int page, int pagesize)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<ResultBlogsForSiteDto>
                {
                    IsSuccess= false,
                };
            }

            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            int totalRow = 0;
            var BlogListQuery = _context.Blogs.Include(s => s.Author).Where(w => w.LanguageId==languageId).OrderByDescending(w => w.InsertTime).AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                BlogListQuery = _context.Blogs.Where(n => n.Title.Contains(SearchKey) || n.Author.Name.Contains(SearchKey) || n.Description.Contains(SearchKey)).AsQueryable();
            }

            return new ResultDto<ResultBlogsForSiteDto>
            {
                Data=new ResultBlogsForSiteDto
                {
                    Blogs=BlogListQuery.Select(
                e => new GetAllBlogSiteDto
                {
                    Id=e.Id,
                    Image = BaseUrl + e.Pic,
                    Author = e.Author.Name,
                    InsertTime = e.InsertTime.Value.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
                    Title = e.Title,
                    Description = e.Description,
                    Slug = e.Slug.Replace(" ", "-"),
                }
                ).ToPaged(page, pagesize, out totalRow).ToList(),
                    TotalRow=totalRow,
                    Paginate=Pagination.PaginateSite(page, pagesize, totalRow, "blogs")
                },
                IsSuccess=true
            };
        }
    }
    public class GetAllBlogSiteDto
    {
        public string Id { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? InsertTime { get; set; }
        public string? Slug { get; set; }

    }
    public class ResultBlogsForSiteDto
    {
        public List<GetAllBlogSiteDto> Blogs { get; set; }
        public int TotalRow { get; set; }
        public string? Paginate { get; set; }

    }
}
