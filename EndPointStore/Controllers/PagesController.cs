using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Pages.Queries.GetAllPagesForSite;

namespace EndPointStore.Controllers
{
    public class PagesController : Controller
    {
        private readonly IGetAllPagesSiteService _getAllPagesSiteService;
        public PagesController(IGetAllPagesSiteService getAllPagesSiteService)
        {
            _getAllPagesSiteService = getAllPagesSiteService;
        }
        [HttpGet]
        public async Task<IActionResult>Detail(string Id)
        {
            var pages =await _getAllPagesSiteService.Execute(Id);
            if(string.IsNullOrEmpty(pages.Content)&&string.IsNullOrEmpty(pages.Title))
            {
                return Redirect("/Home/NotFound");
            }
            return View(pages);
        }
    }
}
