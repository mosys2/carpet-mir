using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using Store.Application.Services.Blogs.Queries.GetDetailBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant.NoImage;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Queries.GetLastedPostsForSite
{
    public interface IGetLastedPostsSiteService
    {
        Task<List<GetLastedPostsDto>> Execute();
    }
    public class GetRelatedPostsSiteService : IGetLastedPostsSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetRelatedPostsSiteService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _language = languege;
        }
        public async Task<List<GetLastedPostsDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetLastedPostsDto>
                { };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var recently =await _context.Blogs.Include(a=>a.Author).Where(w=>w.LanguageId==languageId&&w.IsRemoved==false).OrderByDescending(w=>w.InsertTime)
                .Take(3).Select(i=>new GetLastedPostsDto{
                Author=i.Author.Name,
                Id=i.Id,
                Description=i.Description,
                Image=string.IsNullOrEmpty(i.MinPic)?ImageProductConst.NoImage:BaseUrl+i.MinPic,
                InsertTime = i.InsertTime.Value.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
                Title=i.Title,
                Slug = i.Slug.Replace(" ", "-")

                }).ToListAsync();
                return recently;
        }
    }
    public class GetLastedPostsDto
    {
        public string Id { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? InsertTime { get; set; }
        public string? Slug { get; set; }
    }
    public class BlogCategoryRelatedDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
