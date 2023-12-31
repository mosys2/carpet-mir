﻿using EndPointStore.Models.ProductsViewModel;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Products.Queries.GetSubCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Settings;

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
			var categories = await _productFacadSite.GetCategorySiteService.Execute();
            List<GetSubCategorySiteDto> getSubCategories = new List<GetSubCategorySiteDto>();
            List<CategorySiteDto> getCategorySiteDtos = new List<CategorySiteDto>();
            ViewBag.Setting=setting.Data;
            getCategorySiteDtos.Add(new CategorySiteDto
            {
               Id="2",
			   Name="All",
			   Slug="All",
            });
            getSubCategories.Add(new GetSubCategorySiteDto
            {
                Id = "1",
                Slug = "All",
                Name = "All",
                MainCategory = SuCategories.FirstOrDefault()?.MainCategory,
            });
			getCategorySiteDtos.AddRange(categories);
            getSubCategories.AddRange(SuCategories);
            ProductsViewModel productsViewModel = new ProductsViewModel()
			{
				GetSubCategorySites = getSubCategories,
				ResultProductsForSite=result.Data,
				GetCategorySites=getCategorySiteDtos
			};
			return View(productsViewModel);
		}
		[HttpGet]
		public async Task<IActionResult> Detail(string Id)
		{
            var setting = await _getSettingServices.Execute();
            ViewBag.Setting=setting.Data;

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
