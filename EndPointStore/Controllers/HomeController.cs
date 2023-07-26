using EndPointStore.Models;
using EndPointStore.Models.HomePageViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.HomePages.Queries.GetSliderForSite;
using Store.Application.Services.ProductsSite.FacadPatternSite;
using Store.Application.Services.Results.Queries.GetResultsForSite;
using System.Diagnostics;

namespace EndPointStore.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderForSiteService _getSliderForSiteService;
        private readonly IProductFacadSite _productFacadSite;
        private readonly IGetResultSiteService _getResultSiteService;
		public HomeController(ILogger<HomeController> logger, IGetResultSiteService getResultSiteService, IGetSliderForSiteService getSliderForSiteService, IProductFacadSite productFacadSite)
        {
            _logger = logger;
            _getSliderForSiteService = getSliderForSiteService;
            _productFacadSite= productFacadSite;
            _getResultSiteService = getResultSiteService;
        }
        public async Task<IActionResult> Index()
        {
            var listSlidersSite = await _getSliderForSiteService.Execute();
            var CategoryCarpet = await _productFacadSite.GetCategorySiteService.Execute();
            var ResultsList = await _getResultSiteService.Execute();
            HomePageViewModel homePageView = new HomePageViewModel()
            {
                GetSliderForSites = listSlidersSite,
                CategorySites=CategoryCarpet,
                GetResultSites = ResultsList
            };
            return View(homePageView);
        }

        public  IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}