using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Queries.GetSubCategoryForSite
{
    public interface IGetSubCategorySiteServie
    {
        Task<List<GetSubCategorySiteDto>> Execute(string category);
    }
    public class GetSubCategorySiteServie : IGetSubCategorySiteServie
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetSubCategorySiteServie(IDatabaseContext context,
            IGetSelectedLanguageServices languege
         )
        {
            _context = context;
            _language = languege;
        }
        public async Task<List<GetSubCategorySiteDto>> Execute(string category)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetSubCategorySiteDto>
                {
                   
                };
            }
            category = category.Replace("-", " ");
            var catId=await _context.Category.Where(e=>e.Slug == category||e.Id==category&&e.LanguageId==languageId).FirstOrDefaultAsync();
            if(catId==null)
            {
                return new List<GetSubCategorySiteDto>
                {

                };
            }
          
           
            var SuCategories = _context.Category.Where(r => r.ParentCategoryId == catId.Id && r.LanguageId == languageId)
                         .OrderBy(w=>w.InsertTime)
                         .Select(w => new GetSubCategorySiteDto
                         {
                             Id = w.Id,
                             Name = w.Name,
                             MainCategory=w.ParentCategory.Slug,
                             Slug = w.Slug
                         }).ToList();
          
            return SuCategories;
        }
    }
    public class GetSubCategorySiteDto
    {
        public string Id { get; set; }
        public string? MainCategory { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}
