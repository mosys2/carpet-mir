using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetRelatedPostsForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant.NoImage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetPopularPostsForSite
{
    public interface IGetPopularPostsSiteService
    {
        Task<List<GetPopularPostsDto>> Execute();
    }
    public class GetPopularPostsSiteService : IGetPopularPostsSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetPopularPostsSiteService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _language = languege;
        }
        public async Task<List<GetPopularPostsDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetPopularPostsDto>
                { };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var popular =await _context.Blogs.Where(l => l.LanguageId == languageId && l.IsRemoved == false)
                .OrderByDescending(e => e.View).Take(4).
                Select(w=>new GetPopularPostsDto{
                Id=w.Id,
                Image=string.IsNullOrEmpty(w.MinPic)?ImageProductConst.NoImage:BaseUrl+w.MinPic,
                InsertTime = w.InsertTime.Value.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
                Title =w.Title,
                }).ToListAsync();
            return popular;
        }
    }
    public class GetPopularPostsDto
    {
        public string Id { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? InsertTime { get; set; }
    }
}
