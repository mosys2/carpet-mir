using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Results.Queries.GetResultsForSite
{
    public interface IGetResultSiteService
    {
        Task<List<GetResultSiteDto>> Execute();
    }

    public class GetResultSiteService : IGetResultSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        private readonly IConfiguration _configuration;

        public GetResultSiteService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _language = languege;
            _configuration=configuration;
        }
        public async Task<List<GetResultSiteDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetResultSiteDto>
                {
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;

            var ResultListQuery = _context.Results.Where(o=>o.LanguageId==languageId&&o.IsActive).AsQueryable();
            var ResultList =await ResultListQuery.Select(
                e => new GetResultSiteDto
                {
                  Title=e.Title,
                  Value=e.Value,
                  CssCalass=e.CssClass,
                  Image=BaseUrl+e.Image
                }
                ).ToListAsync();
            return ResultList;
        }
    }
    public class GetResultSiteDto
    {
        public string? Title { get; set; }
        public string? Value { get; set; }
        public string? CssCalass { get; set; }
        public string? Image { get; set; }
    }
}
