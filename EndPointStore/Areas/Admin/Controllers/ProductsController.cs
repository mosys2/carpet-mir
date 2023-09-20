using EndPointStore.Areas.Admin.Models.ViewModelCategory;
using EndPointStore.Areas.Admin.Models.ViewModelFileManager;
using EndPointStore.Areas.Admin.Models.ViewModelProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Application.Services.ProductsSite.Queries.GetProductsList;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Application.Services.ProductsSite.Queries.GetTagsList;
using Store.Application.Services.Users.Command.DeleteUser;
using Store.Application.Services.ProductsSite.Queries.GetEditProductsList;
using EndPointStore.Utilities;
using Store.Application.Services.ProductsSite.Queries.GetBrandsList;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetParentCategory;
using Microsoft.AspNetCore.Authorization;
using Store.Application.Services.SettingsSite.Queries;
using Store.Application.Services.QRCoder;
using QRCoder;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Imaging;
using System.Drawing;

namespace EndPointStore.Areas.Admin.Controllers
{

	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
	{
		private readonly IProductFacad _productFacad;
        private readonly IGetSettingServices _getSettingServices;
		private readonly IQRService _qRService;

        public ProductsController(IProductFacad productFacad, IGetSettingServices getSettingServices,IQRService qRService)
		{
			_productFacad = productFacad;
			_getSettingServices = getSettingServices;
			_qRService = qRService;

        }
		[HttpGet]
		public async Task<IActionResult> Index(string searchkey, int page = 1)
		{
            var pagesize = _getSettingServices.Execute().Result.Data.ShowPerPage;
            var listProducts = await _productFacad.GetProductsListService.Execute(
				new RequstGetProductsDto
				{
					SearchKey = searchkey,
					Page = page,
					PageSize= pagesize,
                    Category = null,
                    Tag = null
                }
				);
			return View(listProducts);
		}
		[HttpPost]
		public async Task<IActionResult> AddTag(string nameTag)
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var resultTag = await _productFacad.AddTagService.Execute(nameTag);
			return Json(resultTag);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			
            var listCategory = await _productFacad.GetParentCategory.Execute();
			var listBrands = await _productFacad.GetBrandListService.Execute();
            List<BrandsListDto> ItemBrands = new List<BrandsListDto>();
            ItemBrands.Add(new BrandsListDto
            {
                Id = "",
                Name = "بدون انتخاب"
            });
			ItemBrands.AddRange(listBrands);
            var listTags = await _productFacad.GetTagsListService.Execute();
			ViewModelProducts viewModelProducts = new ViewModelProducts()
			{
				AddNewProduct = new AddNewProductView(),
				Brands = listBrands,
				ParentCategory = listCategory
			};
			ViewBag.Category = new SelectList(listCategory, "Id", "Name");
			ViewBag.Brands = new SelectList(ItemBrands, "Id", "Name");
			ViewBag.Tags = new SelectList(listTags, "Id", "Name");

			return View(viewModelProducts);
		}
		[HttpPost]
		public async Task<IActionResult> Create(AddNewProductView product)
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
            var userId = ClaimUtility.GetUserId(User);
			if(userId == null)
			{
				return Json(new ResultDto() {
				IsSuccess=false,
				Message=MessageInUser.MessageUserNotLogin
				});
			}
            var resultProduct = await _productFacad.AddProductService.Execute(
				new RequestAddProductDto
				{
					Name = product.Name,
					Price = product.Price,
					Quantity = product.Quantity,
					PostageFee = product.PostageFee,
					PostageFeeBasedQuantity = product.PostageFeeBasedQuantity,
					Slug = product.Slug,
					IsActive = product.IsActive,
					MinPic = product.MinPic,
					Pic = product.Pic,
					Content = product.Content,
					Description=product.Description,
					CategoryId = product.CategoryId,
					BrandId = product.BrandId,
					UserId =userId,
					TagsId = product.TagsId,
					FeatureList = product.FeatureList,
					UrlImagList = product.UrlImagList,
				}
				);
			return Json(resultProduct);
		}

		[HttpPost]
		public async Task<IActionResult> GetListTags()
		{
			var tags = await _productFacad.GetTagsListService.Execute();
			return Json(new ResultDto<List<TagsListDto>>
			{
				Data = tags,
				IsSuccess = true,
				Message = ""
			});
		}

        

        [HttpPost]
		public async Task<IActionResult> Delete(string ProductId)
		{
			var resultRemove = await _productFacad.RemoveProductService.Execute(ProductId);
			return Json(resultRemove);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(string Id)

		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var listCategory = await _productFacad.GetParentCategory.Execute();
			var listBrands = await _productFacad.GetBrandListService.Execute();
			var listTags = await _productFacad.GetTagsListService.Execute();
			ViewBag.Category = new SelectList(listCategory, "Id", "Name");
			ViewBag.Brands = new SelectList(listBrands, "Id", "Name");
			ViewBag.Tags = new SelectList(listTags, "Id", "Name");
			var product = await _productFacad.GetEditProductListService.Execute(Id);
			return View(product);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(EditProductListDto editProductListDto)
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var userId = ClaimUtility.GetUserId(User);
			if (userId == null)
			{
				return Json(new ResultDto()
				{
					IsSuccess = false,
					Message = MessageInUser.MessageUserNotLogin
				});
			}
			var resulEdit =await _productFacad.EditProductsService.Execute(
				new EditProductListDto
				{

					Id = editProductListDto.Id,
					BrandId = editProductListDto.BrandId,
					CategoryId = editProductListDto.CategoryId,
					Content = editProductListDto.Content,
					Description=editProductListDto.Description,
					Name = editProductListDto.Name,
					FeatureList= editProductListDto.FeatureList,
					IsActive=editProductListDto.IsActive,
					LastPrice=editProductListDto.LastPrice,
					Price = editProductListDto.Price,
					MinPic=editProductListDto.MinPic,
					Pic = editProductListDto.Pic,
					PostageFee=editProductListDto.PostageFee,
					PostageFeeBasedQuantity = editProductListDto.PostageFeeBasedQuantity,
					Quantity=editProductListDto.Quantity,
					Slug=editProductListDto.Slug,
					TagsId=editProductListDto.TagsId,
					UrlImagList= editProductListDto.UrlImagList,
					UserId= userId
				}
				);
			return Json(resulEdit);
		}
		[HttpPost]
		public async Task<IActionResult> QrCode(string pId)
		{

			var setting = await _getSettingServices.Execute();
            string url = $"{setting.Data.BaseUrl}products/detail/{pId}";
            string QRImg = "";
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap obitmap = qrCode.GetGraphic(20))
                {
                    obitmap.Save(ms, ImageFormat.Png);
                    QRImg="data:image/jpeg;base64,"+Convert.ToBase64String(ms.ToArray());
                }
            }

			var result = new ResultDto<string>
			{
				Data = QRImg,
				IsSuccess = true,
			};
			return Json(result);
		}
	}
}
