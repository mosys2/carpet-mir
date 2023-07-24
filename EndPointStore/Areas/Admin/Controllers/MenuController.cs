using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Menu.Queries.IGetMenu;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly IGetAllLanguegeService _getAllLanguegeService;
        private readonly IGetMenuService _getMenuService;
        public MenuController(IGetAllLanguegeService getAllLanguegeService,IGetMenuService getMenuService)
        {
            _getAllLanguegeService = getAllLanguegeService;
            _getMenuService = getMenuService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? LanguegeId)
        {
            var languages = await _getAllLanguegeService.Execute();
            ViewBag.AllLanguages = new SelectList(languages, "Id", "Name");
            var result =await _getMenuService.Execute(LanguegeId);
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(List<MenuItemDto> model)
        {
            return Ok();
        }
    }
}
