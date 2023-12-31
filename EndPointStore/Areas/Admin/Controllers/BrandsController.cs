﻿using EndPointStore.Areas.Admin.Models.ViewModelBrand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Products.Commands.AddNewBrand;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public BrandsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listBrands=await _productFacad.GetBrandListService.Execute();
            ViewModelBrand viewModelBrand = new ViewModelBrand()
            {
                AddBrandView = new AddBrandViewDto(),
                BrandsLists=listBrands,
            };
            return View(viewModelBrand);
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandsDto brandsDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result=await _productFacad.AddNewBrandService.Execute(new BrandsDto
            { 
             Id=brandsDto.Id,
             Image=brandsDto.Image,
             Name = brandsDto.Name,
             Slug = brandsDto.Slug
            }
            );
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBrand(string brandId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _productFacad.RemoveBrandService.Execute(brandId);
            return Json(result);
        }
    }
}
