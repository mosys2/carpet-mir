using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
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
        private readonly IGetSelectedLanguageServices _language;
        private readonly IConfiguration _configuration;

        public GetBrandListService(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices language)
        {
            _context = context;
            _configuration= configuration;
            _language = language;
        }
        public async Task<List<BrandsListDto>> Execute()
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<BrandsListDto>
                {
                };
            }
            var Brands = _context.Brands.Include(t => t.Language)
                .Where(r => r.LanguageId==languageId)
                .Select(b => new BrandsListDto
                {
                    Name = b.Name,
                    CssClass = b.CssClass,
                    Id = b.Id,
                    Pic = string.IsNullOrEmpty(b.Pic) ? ImageProductConst.NoImage : BaseUrl +b.Pic,
                    Slug = b.Slug,
                    Url= string.IsNullOrEmpty(b.Pic) ? ImageProductConst.NoImage : b.Pic,
                    InsertTime =b.InsertTime,
                }
            ).ToList();
            return Brands;
        }
    }
}
