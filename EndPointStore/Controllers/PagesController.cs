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
        public async Task<IActionResult>Index()
        {
            var pages =await _getAllPagesSiteService.Execute();
            return View(pages);
        }
    }
}
