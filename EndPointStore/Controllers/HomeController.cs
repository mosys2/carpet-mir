using EndPointStore.Models;
using EndPointStore.Models.HomePageViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Colors.Queries.GetAllColor;
using Store.Application.Services.FileManager.Commands.UploadFiles;
using Store.Application.Services.HomePages.Queries.GetSliderForSite;
using Store.Application.Services.Materials.Queries.GetAllMaterial;
using Store.Application.Services.Newsletters.Commands.AddNewsletter;
using Store.Application.Services.Pages.Queries.GetAllPagesForSite;
using Store.Application.Services.Products.Commands.RegisterCustomCarpet;
using Store.Application.Services.ProductsSite.FacadPatternSite;
using Store.Application.Services.Results.Queries.GetResultsForSite;
using Store.Application.Services.SettingsSite.Queries;
using Store.Application.Services.Shapes.Queries.GetAllShape;
using Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite;
using Store.Application.Services.Sizes.Queries.GetAllSize;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.OrderCarpet;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace EndPointStore.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderForSiteService _getSliderForSiteService;
        private readonly IProductFacadSite _productFacadSite;
        private readonly IGetResultSiteService _getResultSiteService;
        private readonly IBlogFacadSite _blogFacadSite;
        private readonly IGetAllPagesSiteService _getAllPagesSiteService;
        private readonly IGetSettingServices _getSettingServices;
        private readonly IGetAllSizeService _getAllSizeService;
        private readonly IGetAllColorService _getAllColorService;
        private readonly IGetAllMaterialService _getAllMaterialService;
        private readonly IGetAllShapeService _getAllShapeService;
        private readonly IAddNewsletterservice _newsletterservice;
        private readonly IProductFacad _productFacad;
        private readonly IUploadFileService _uploadFileService;

        public HomeController(ILogger<HomeController> logger
            ,IBlogFacadSite blogFacadSite,
            IGetResultSiteService getResultSiteService,
            IGetSliderForSiteService getSliderForSiteService,
            IGetAllPagesSiteService getAllPagesSiteService,
            IProductFacadSite productFacadSite,
            IGetSettingServices getSettingServices,
            IGetAllColorService getAllColorService,
            IGetAllMaterialService getAllMaterialService,
            IGetAllShapeService getAllShapeService,
            IGetAllSizeService getAllSizeService,
            IAddNewsletterservice newsletterservice,
            IProductFacad productFacad,
            IUploadFileService uploadFileService
          )
        {
            _logger = logger;
            _getSliderForSiteService = getSliderForSiteService;
            _productFacadSite = productFacadSite;
            _getResultSiteService = getResultSiteService;
            _getAllPagesSiteService = getAllPagesSiteService;
            _blogFacadSite = blogFacadSite;
            _getSettingServices = getSettingServices;
            _getAllMaterialService = getAllMaterialService;
            _getAllShapeService = getAllShapeService;
            _getAllSizeService = getAllSizeService;
            _getAllColorService = getAllColorService;
            _newsletterservice=newsletterservice;
            _productFacad = productFacad;
            _uploadFileService = uploadFileService;
        }
        public async Task<IActionResult> Index()
        {
            var listSlidersSite = await _getSliderForSiteService.Execute();
            var CategoryCarpet = await _productFacadSite.GetCategorySiteService.Execute();
            var ResultsList = await _getResultSiteService.Execute();
            var LastedBlogsSite = await _blogFacadSite.GetLastedPostsSiteService.Execute();
            var settings = await _getSettingServices.Execute();
            ViewBag.Register =  _getAllPagesSiteService.Execute("Order Request Form").Result;
            ViewBag.RequestReview =  _getAllPagesSiteService.Execute("Request Review").Result;
            ViewBag.Designing =  _getAllPagesSiteService.Execute("Designing").Result;
            ViewBag.Contract =  _getAllPagesSiteService.Execute("Contract").Result;
            ViewBag.Manufacturing =  _getAllPagesSiteService.Execute("Carpet Manufacturing").Result;
            //Fill To RegisterCarpetForm
            var category= await _productFacad.GetParentCategory.Execute();
            var sizes =  _getAllSizeService.Execute().Result.Data.OrderBy(e=>e.Width);
            var colors =  _getAllColorService.Execute().Result.Data.OrderBy(e => e.Name);
            var materials =  _getAllMaterialService.Execute().Result.Data.OrderBy(e => e.Name);
            var shapes =  _getAllShapeService.Execute().Result.Data.OrderBy(e => e.Name);
            ViewBag.Category = new SelectList(category, "Id", "Name");
            ViewBag.Sizes = new SelectList(sizes, "Id", "Meterage");
            ViewBag.Colors = new SelectList(colors, "Id", "Name");
            ViewBag.Materials = new SelectList(materials, "Id", "Name");
            ViewBag.Shapes = new SelectList(shapes, "Id", "Name");
            HomePageViewModel homePageView = new HomePageViewModel()
            {
                GetSliderForSites = listSlidersSite,
                CategorySites=CategoryCarpet,
                GetResultSites = ResultsList,
                GetLastedPosts= LastedBlogsSite,
                RegisterCustomCarpetModel=new RegisterCustomCarpetModel(),
                Setting=settings.Data
            };
            return View(homePageView);
        }
        [HttpGet]
        public async Task<IActionResult> RegisterCustomCarpet()
        {
            //Fill To RegisterCarpetForm
            var category = await _productFacad.GetParentCategory.Execute();
            var sizes = _getAllSizeService.Execute().Result.Data.OrderBy(e => e.Width);
            var colors = _getAllColorService.Execute().Result.Data.OrderBy(e => e.Name);
            var materials = _getAllMaterialService.Execute().Result.Data.OrderBy(e => e.Name);
            var shapes = _getAllShapeService.Execute().Result.Data.OrderBy(e => e.Name);
            ViewBag.Category = new SelectList(category, "Id", "Name");
            ViewBag.Sizes = new SelectList(sizes, "Id", "Meterage");
            ViewBag.Colors = new SelectList(colors, "Id", "Name");
            ViewBag.Materials = new SelectList(materials, "Id", "Name");
            ViewBag.Shapes = new SelectList(shapes, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCustomCarpet(RegisterCustomCarpetModel registerCustom)
        {
            if(!ModelState.IsValid)
            {
                return Json(new ResultDto {
                IsSuccess=false,
                Message=MessageInUser.InvalidFormEn,
                });
            }
            var result =await _productFacadSite.RegisterCustomCarpetSiteService.Execute(
                new RegisterCustomCarpetDto
                {
                    Address = registerCustom.Address,
                    Name = registerCustom.Name,
                    CategoryId = registerCustom.CategoryId,
                    ColorId = registerCustom.ColorId,
                    Country=registerCustom.Country,
                    DeliveryDate=registerCustom.DeliveryDate,
                    Email=registerCustom.Email,
                    MaterialId = registerCustom.MaterialId,
                    PhoneNumber= registerCustom.PhoneNumber,
                    ShapeId = registerCustom.ShapeId,
                    SizeId=registerCustom.SizeId,
                    TypeName=registerCustom.TypeName,
                    Image=registerCustom.Image,
                    Descriptin=registerCustom.Description
                }
                );
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterNewsletter(NewsletterDto newsletter)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto { IsSuccess=false, Message=MessageInUser.InvalidFormEn });
            }
            var result = await _newsletterservice.Execute(newsletter.EmailNewsletter);
            return Json(result);
        }
        public async Task<IActionResult> NotFound()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IEnumerable<IFormFile> File)
        {
            var result = await _uploadFileService.ExecuteSite(File);
            return Json(result);
        }
    }
}