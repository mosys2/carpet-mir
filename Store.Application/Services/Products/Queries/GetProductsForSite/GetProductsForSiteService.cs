using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Common;
using Store.Common.Constant.NoImage;
using Store.Common.Constant.Settings;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Translate;

namespace Store.Application.Services.ProductsSite.Queries.GetProductsForSite
{
    public class GetProductsForSiteService : IGetProductsForSiteService
	{
		private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetProductsForSiteService(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices languege)
        {
			_context = context;
			_configuration = configuration;
            _language = languege;
        }
        public async Task<ResultDto<ResultProductsForSiteDto>> Execute(Ordering ordering,string Tag, string Category,string SubCategory, string SearchKey, int page, int pagesize)
		{
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<ResultProductsForSiteDto>
                {
                    IsSuccess = false,
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            int totalRow = 0;
            DateTime lastWeekDate = DateTime.Now.AddDays(-7);
            var products = _context.Products.Include(r => r.Rates).Include(b=>b.Brand).Include(c=>c.Category).Where(l=>l.LanguageId==languageId).AsQueryable();
			if(!string.IsNullOrWhiteSpace(SearchKey) )
			{
				products = _context.Products.Where(n => n.Name.Contains(SearchKey) || n.Brand.Name.Contains(SearchKey) || n.Category.Name.Contains(SearchKey)).AsQueryable();
			}
            if (!string.IsNullOrWhiteSpace(Category)&&string.IsNullOrEmpty(SubCategory))
            {
                Category = Category.Replace("-", " ");
                var CategoryId = await _context.Category.Where(r => r.Slug == Category || r.Id == Category).FirstOrDefaultAsync();
                if (CategoryId != null)
                {
                    products = _context.Category.Where(c => c.ParentCategoryId == CategoryId.Id)
                         .Include(c => c.Products)
                         .Include(c => c.SubCategories)
                         .SelectMany(c => c.Products)
                         .AsQueryable();
						
                    
                }
            }
            if(!string.IsNullOrEmpty(SubCategory))
            {
                SubCategory=SubCategory.Replace("-", " ");
                var checkSub = _context.Category.Where(r => r.Slug == SubCategory ||  r.Id == SubCategory).FirstOrDefault();
                if (checkSub != null)
                {
                    products = _context.Products.Where(c => c.CategoryId == checkSub.Id).AsQueryable();
                }
            }
            if (!string.IsNullOrWhiteSpace(Tag))
            {
                Tag = Tag.Replace("-", " ");
                var TagId = await _context.Tags.Where(r => r.Name == Tag || r.Id == Tag).FirstOrDefaultAsync();
                if (TagId != null)
                {
                    products = _context.Tags.Where(c => c.Id == TagId.Id)
                        .SelectMany(v => v.ItemTags)
                        .Select(o => o.Product).AsQueryable();
                }
            }
            switch (ordering)
			{
				case Ordering.NotOrder:
					products = products.OrderByDescending(i => i.Id).AsQueryable();
					break;
				case Ordering.MostVisited:
                    products = products.OrderByDescending(i => i.ViewCount).AsQueryable();
					break;
                case Ordering.Bestselling:
					break;
				case Ordering.MostPopular:
					break;
				case Ordering.theNewest:
                    products = products.OrderByDescending(i => i.InsertTime).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    products = products.OrderBy(p => p.Price).AsQueryable();
                    break;
                case Ordering.theMostExpensive:
                    products = products.OrderByDescending(p => p.Price).AsQueryable();
                    break;
                default:
					break;
			}
			return new ResultDto<ResultProductsForSiteDto> {

				Data = new ResultProductsForSiteDto
				{
					Products = products.Select(w => new ProductsForSiteDto
					{
						Id = w.Id,
						Image = string.IsNullOrEmpty(w.MinPic) ? ImageProductConst.NoImage : BaseUrl + w.MinPic,
						Price = w.Price,
						Unit = Settings.UnitText,
						LastPrice = w.LastPrice,
						//Discount = (float)((w.LastPrice - w.Price) / w.LastPrice) * 100,
						Star = w.Rates.Select(e => e.UserRate).FirstOrDefault(),
						NewProduct = w.InsertTime >= lastWeekDate ?true:false,
						Title = w.Name,
						Description= w.Description,
                        Slug=w.Slug,
					}).ToPaged(page, pagesize, out totalRow).ToList(),
                    TotalRow = totalRow,
                    Paginate = Pagination.PaginateSite(page, pagesize, totalRow, "products", SearchKey, Tag, Category)
                },
                IsSuccess=true,
            };
		}
    }
}
