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

namespace Store.Application.Services.Blogs.Queries.GetRelatedPostsForSite
{
    public interface IGetRelatedPostsSiteService
    {
        Task<List<GetRelatedPostsDto>> Execute();
    }
    public class GetRelatedPostsSiteService : IGetRelatedPostsSiteService
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
        public async Task<List<GetRelatedPostsDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetRelatedPostsDto>
                { };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var recently =await _context.Blogs.Include(a=>a.Author).Where(w=>w.LanguageId==languageId&&w.IsRemoved==false).OrderByDescending(w=>w.InsertTime)
                .Take(3).Select(i=>new GetRelatedPostsDto{
                Author=i.Author.Name,
                Id=i.Id,
                Description=i.Description,
                Image=string.IsNullOrEmpty(i.MinPic)?ImageProductConst.NoImage:BaseUrl+i.MinPic,
                InsertTime = i.InsertTime.Value.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
                Title=i.Title
                }).ToListAsync();
                return recently;
            //string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            //var CategoryInBlog =await _context.Blogs.Where(p => p.LanguageId == languageId&&p.Id==Id).Include(i => i.ItemCategoryBlogs).ThenInclude(p => p.CategoryBlog)
            //    .FirstOrDefaultAsync();
            /////
            //if(CategoryInBlog==null)
            //{
            //    return new List<GetRelatedPostsDto>
            //    { };
            //}
            //
           // List<BlogCategoryRelatedDto> Category = CategoryInBlog.ItemCategoryBlogs.Select(w => new BlogCategoryRelatedDto
           // {
           //     Id = w.CategoryBlog.Id,
           //     Name = w.CategoryBlog.Name,
           // }).ToList();
           // ///
           // var RelatedPost = _context.Blogs.Where(p=>p.LanguageId==languageId).Include(i => i.ItemCategoryBlogs).ThenInclude(p => p.CategoryBlog)
           //     .AsQueryable();
           // if(RelatedPost==null)
           // {
           //     return new List<GetRelatedPostsDto>
           //     { };
           // }
           //var ListRelated=new List<GetRelatedPostsDto>();
           // if(Category.Count>0)
           // {
           //     foreach (var item in Category)
           //     {
           //         ListRelated.Add(new GetRelatedPostsDto{
           //         Id=RelatedPost.Where(r => r.ItemCategoryBlogs.Any(g => g.CategoryBlog.Name.Contains(item.Name))).FirstOrDefault().Id,
           //         Author= RelatedPost.Where(r => r.ItemCategoryBlogs.Any(g => g.CategoryBlog.Name.Contains(item.Name))).FirstOrDefault().Author.Name,
           //         Description= RelatedPost.Where(r => r.ItemCategoryBlogs.Any(g => g.CategoryBlog.Name.Contains(item.Name))).FirstOrDefault().Description,
           //         Image= RelatedPost.Where(r => r.ItemCategoryBlogs.Any(g => g.CategoryBlog.Name.Contains(item.Name))).FirstOrDefault().Pic,
           //         Title = RelatedPost.Where(r => r.ItemCategoryBlogs.Any(g => g.CategoryBlog.Name.Contains(item.Name))).FirstOrDefault().Title
           //         }); 
           //     }
           // }
           // var random = new Random();
           // var totalPosts = ListRelated.Count;
           // var uniqueRandomIndices = new HashSet<int>();
           // while (uniqueRandomIndices.Count < 3)
           // {
           //     var randomIndex = random.Next(0, totalPosts);
           //     uniqueRandomIndices.Add(randomIndex);
           // }
           //var randomPosts=uniqueRandomIndices.Select(index => ListRelated[index]).ToList();
           // return  randomPosts.Select(e => new GetRelatedPostsDto
           // {
           //     Author=e.Author,
           //     Description=e.Description,
           //     Id=e.Id,
           //     Image=BaseUrl+e.Image,
           //     //InsertTime = e.InsertTime.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture),
           //     Title=e.Title
           // }).ToList();

        }
    }
    public class GetRelatedPostsDto
    {
        public string Id { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? InsertTime { get; set; }
    }
    public class BlogCategoryRelatedDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
