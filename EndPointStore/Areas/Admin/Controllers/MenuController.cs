using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Menu.Commands.AddNewMenu;
using Store.Application.Services.Menu.Queries.IGetMenu;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly IGetMenuService _getMenuService;
        private readonly IAddNewMenuService _addNewMenuService;
        public MenuController(IGetMenuService getMenuService,IAddNewMenuService addNewMenuService)
        {
            _getMenuService = getMenuService;
            _addNewMenuService = addNewMenuService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? LanguegeId)
        {
            var result =await _getMenuService.Execute(LanguegeId);
            ViewBag.Id = result.Id;
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(List<MenuItemDto> model,string Id)
        {
            var result =await _addNewMenuService.Execute(model,Id);
            return Json(result);
        }
    }
}
