using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
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
        Task<List<GetAllBlogSiteDto>> Execute();
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
        public async Task<List<GetAllBlogSiteDto>> Execute()
        {
            //string languageId = _language.Execute().Result.Data.Id ?? "";
            //if (string.IsNullOrEmpty(languageId))
            //{
            //    return new List<ParentCategoryDto>
            //    {
            //    };
            //}

            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var BlogListQuery = _context.Blogs.Include(s => s.Author).OrderByDescending(w=>w.InsertTime).AsQueryable();
            var BlogList =await BlogListQuery.Select(
                e => new GetAllBlogSiteDto
                {
                    Image = BaseUrl + e.Pic,
                    Author=e.Author.Name,
                    InsertTime=e.InsertTime.Value.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
                    Title=e.Title,
                }
                ).ToListAsync();
            return BlogList;
        }
    }
    public class GetAllBlogSiteDto
    {
        public string Image { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string InsertTime { get; set; }

    }
}
