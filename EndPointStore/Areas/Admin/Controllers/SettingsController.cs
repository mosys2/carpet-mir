using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Langueges.Queries;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly IGetAllLanguegeService _getAllLanguegeService;
        public SettingsController(IGetAllLanguegeService getAllLanguegeService)
        {
            _getAllLanguegeService=getAllLanguegeService;
        }

        public async Task<IActionResult> Index()
        {
            var languages =await _getAllLanguegeService.Execute();
            ViewBag.AllLanguages=new SelectList(languages, "Id", "Name");
            return View();
        }
    }
}
