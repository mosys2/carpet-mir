using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetDetailBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Constant.Settings;
using Store.Common.Dto;
using Store.Domain.Entities.Translate;

namespace Store.Application.Services.ProductsSite.Queries.GetDetailProductsForSite
{
    public class GetDetailProductSiteService:IGetDetailProductSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetDetailProductSiteService(IDatabaseContext context,
            IConfiguration configuration
            , IGetSelectedLanguageServices language
            )
        {
            _context = context;
            _configuration = configuration;
            _language=language;
        }

        public async Task<DetailProductSiteDto> Execute(string idProduct)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new DetailProductSiteDto();
               
            }
           
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var lastWeekDate = DateTime.Now.AddDays(-7);
            var detailProductList =await _context.Products.Where(r =>r.LanguageId==languageId&&(r.Slug==idProduct.Replace("-"," ")|| r.Id == idProduct))
                 .Include(it => it.ItemTags)
                 .ThenInclude(g => g.Tag).Include(i => i.Medias)
                 .Include(f => f.Features).
                  Include(b => b.Brand).Include(r => r.Rates)
                 .Include(e=>e.Category)
                 .FirstOrDefaultAsync();
            if (detailProductList == null) 
            { 
              return new DetailProductSiteDto();
            }
            //ListImages
            List<ImagesListDto> imagesList = new List<ImagesListDto>();
            imagesList.Add(new ImagesListDto { Url = BaseUrl + detailProductList.Pic });
            imagesList.AddRange(detailProductList.Medias.Select(d => new ImagesListDto {Url= BaseUrl + d.Src }));
            detailProductList.ViewCount++;
            await _context.SaveChangesAsync();
                return new DetailProductSiteDto
                {
                    Id = detailProductList.Id,
                    Brand = detailProductList.Brand.Name==null?"": detailProductList.Brand.Name,
                    CodeProduct = detailProductList.CodeProduct,
                    Content = detailProductList.Content,
                    Description = detailProductList.Description,
                    Unit=Settings.UnitText,
                    FeatureList = detailProductList.Features.Select(q => new FeatureListDto { Title = q.DisplayName, Value = q.Value }).ToList(),
                    LastPrice = detailProductList.LastPrice,
                    Name = detailProductList.Name,
                    Category=detailProductList.Category.Name,
                    Price = detailProductList.Price,
                    Keywords="",
                    Slug=detailProductList.Slug,
                    NewProduct = detailProductList.InsertTime >= lastWeekDate ? true : false,
                    Discount = (float)Math.Round(((detailProductList.LastPrice - detailProductList.Price) / detailProductList.LastPrice) * 100, 1),
                    Star = detailProductList.Rates.Select(c => c.UserRate).FirstOrDefault(),
                    Tags = detailProductList.ItemTags.Select(c => new TagsListDto
                    {
                        Id = c.TagId,
                        Name = c.Tag.Name
                    }).ToList(),
                    UrlImagList = imagesList

                };
        }
    }
}
