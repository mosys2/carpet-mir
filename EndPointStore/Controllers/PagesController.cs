using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Pages.Queries.GetAllPagesForSite;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant.GroupTypes;

namespace EndPointStore.Controllers
{
    public class PagesController : Controller
    {
        private readonly IGetAllPagesSiteService _getAllPagesSiteService;
        private readonly IGetSettingServices _getSettingServices;

        public PagesController(IGetAllPagesSiteService getAllPagesSiteService,
            IGetSettingServices getSettingServices)
        {
            _getAllPagesSiteService = getAllPagesSiteService;
            _getSettingServices = getSettingServices;
        }
        [HttpGet]
        public async Task<IActionResult>Detail(string Id,string? Type)
        {
            //GetAllPagesSiteDto pages;
            //if (Type!=null)
            //{
           var pages = await _getAllPagesSiteService.Execute(Id, GroupType.DownloadCatalouge);
            //}
            //else
            //{
            //pages = await _getAllPagesSiteService.Execute(Id, null);
            //}
            var setting=await _getSettingServices.Execute(); ViewBag.Setting=setting.Data;
            if (string.IsNullOrEmpty(pages.Content)&&string.IsNullOrEmpty(pages.Title))
            {
                return Redirect("/Home/NotFound");
            }
            return View(pages);
        }
    }
}
