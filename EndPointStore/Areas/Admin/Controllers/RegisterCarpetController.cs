using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Products.Queries.GetAllRegisterCustomCarpet;
using Store.Application.Services.SettingsSite.Queries;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RegisterCarpetController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IGetSettingServices _getSettingServices;
        public RegisterCarpetController(IProductFacad productFacad, IGetSettingServices getSettingServices)
        {
            _productFacad = productFacad;
            _getSettingServices = getSettingServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? searchkey, int Page = 1)
        {
            var pagesize = _getSettingServices.Execute().Result.Data.ShowPerPage;
            var listRegisterCarpet =await _productFacad.GetAllRegisterCustomCarpetService.Execute(
                new RequestGetRegisterCustomCarpetDto
                {
                    Page = Page,
                    SearchKey = searchkey,
                    PageSize = pagesize,
                }
                );
            return View(listRegisterCarpet);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string Id)
        {
            var detail = await _productFacad.GetDetailCustomCarpetService.Execute(Id);
            return View(detail);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string registerId)
        {
            var result = await _productFacad.RemoveRegisterCustomCarpetService.Execute(registerId);
            return Json(result);
        }
    }
}
