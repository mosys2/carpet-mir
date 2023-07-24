using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SettingsSite.Commands;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly IGetSettingServices _getSettingServices;
        private readonly IEditSettingServices _editSettingServices;
        public SettingsController(IGetSettingServices getSettingServices, IEditSettingServices editSettingServices )
        {
            _getSettingServices=getSettingServices;
            _editSettingServices=editSettingServices;
        }

        public async Task<IActionResult> Index()
        {
            var setting = _getSettingServices.Execute().Result.Data;
            return View(setting);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditSettingDto data)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto()
                {
                    IsSuccess=false,
                    Message=MessageInUser.InvalidForm
                });
            }
            var result =  _editSettingServices.Execute(data).Result;
            return Json(result);
        }



    }
}
