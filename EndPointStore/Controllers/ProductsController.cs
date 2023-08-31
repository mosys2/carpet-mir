using EndPointStore.Models.ProductsViewModel;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Products.Queries.GetSubCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Controllers
{
    public class ProductsController : Controller
    {
		private readonly IProductFacadSite _productFacadSite;
        private readonly IGetSettingServices _getSettingServices;
        public ProductsController(IProductFacadSite productFacadSite, IGetSettingServices getSettingServices)
		{
			_productFacadSite = productFacadSite;
			_getSettingServices = getSettingServices;
		}
		[HttpGet]
		public async Task<IActionResult> Index(Ordering ordering, int page = 1, string? searchKey = "", string? tag = "", string? category = "",string subcategory="")
		{
            var setting = await _getSettingServices.Execute();
            var pagesize = setting.Data.ShowPerPage;
            var result = await _productFacadSite.GetProductsForSiteService.Execute(ordering, tag,category,subcategory,searchKey, page, pagesize);
			var SuCategories = await _productFacadSite.GetSubCategorySiteServie.Execute(category);
            List<GetSubCategorySiteDto> getSubCategories = new List<GetSubCategorySiteDto>();
            getSubCategories.Add(new GetSubCategorySiteDto
            {
                Id = "1",
                Slug = "All",
                Name = "All",
                MainCategory = SuCategories.FirstOrDefault()?.MainCategory,
            });
            getSubCategories.AddRange(SuCategories);
            ProductsViewModel productsViewModel = new ProductsViewModel()
			{
				GetSubCategorySites = getSubCategories,
				ResultProductsForSite=result.Data
			};
			return View(productsViewModel);
		}
		[HttpGet]
		public async Task<IActionResult> Detail(string Id)
		{
			if (!ModelState.IsValid)
			{
                return Redirect("/Home/NotFound");
            }
			var resultDetail = await _productFacadSite.GetDetailProductSiteService.Execute(Id);
			return View(resultDetail);
		}
		//      [HttpPost]
		//      public async Task<IActionResult> GetProductDetail(string productId)
		//      {
		//          if (!ModelState.IsValid)
		//          {
		//              return Json(new ResultDto
		//              {
		//                  IsSuccess = false,
		//                  Message = MessageInUser.IsValidForm
		//              });
		//          }
		//          var result = await _productFacadSite.DetailProductModalSiteService.Execute(productId);
		//          return Json(result);
		//      }
	}
}
