using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SettingsSite.Queries;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly IGetSettingServices _getSettingServices;
        public SettingsController(IGetSettingServices getSettingServices)
        {
            _getSettingServices=getSettingServices;
        }

        public async Task<IActionResult> Index()
        {
            var setting = _getSettingServices.Execute().Result.Data;
            return View(setting);
        }
    }
}
