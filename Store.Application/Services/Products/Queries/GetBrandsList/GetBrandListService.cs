using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant.NoImage;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetBrandsList
{
    public class GetBrandListService : IGetBrandListService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        public GetBrandListService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration= configuration;
        }
        public async Task<List<BrandsListDto>> Execute(string? languageId)
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var Brands = _context.Brands.Include(t => t.Language).AsQueryable();
            if (!string.IsNullOrEmpty(languageId))
            {
                Brands=Brands.Where(r => r.LanguageId==languageId);
            }

            //Get List Brands
            var Brandlist = Brands.Include(t=>t.Language).Where(r=>r.IsRemoved==false).OrderByDescending(w=>w.InsertTime)
                .Select(b => new BrandsListDto
            {
                Name = b.Name,
                CssClass = b.CssClass,
                Id = b.Id,
                Pic = string.IsNullOrEmpty(b.Pic) ? ImageProductConst.NoImage:BaseUrl +b.Pic,
                Slug = b.Slug,
                Url= string.IsNullOrEmpty(b.Pic) ? ImageProductConst.NoImage:b.Pic,
                InsertTime =b.InsertTime,
                LanguegeId=b.LanguageId,
                LanguegeName=b.Language.Name
            }
            ).ToList();
            return Brandlist;
        }
    }
}
