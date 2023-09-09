using Store.Application.Services.Products.Queries.GetSubCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;

namespace EndPointStore.Models.ProductsViewModel
{
    public class ProductsViewModel
    {
        public ResultProductsForSiteDto ResultProductsForSite { get; set; }
        public List<GetSubCategorySiteDto> GetSubCategorySites { get; set; }
        public List<CategorySiteDto> GetCategorySites { get; set; }
    }
}
