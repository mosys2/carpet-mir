using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.ContactsUs.Commands.RemoveContactUs;
using Store.Application.Services.ContactsUs.Queries.GetAllContactUs;
using Store.Application.Services.ContactsUs.Queries.GetShowContactUs;
using Store.Application.Services.SettingsSite.Queries;

namespace EndPointStore.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactUsController : Controller
	{
		private readonly IGetAllContactUsService _allContactUsService;
        private readonly IGetShowContactUsService _getShowContactUsService;
        private readonly IRemoveContactUsService _removeContactUsService;
        private readonly IGetSettingServices _getSettingServices;

        public ContactUsController(IGetAllContactUsService getAllContactUsService
            ,IGetShowContactUsService getShowContactUsService
            ,IRemoveContactUsService removeContactUsService
            ,IGetSettingServices settingServices
			)
        {
			_allContactUsService = getAllContactUsService;
            _getShowContactUsService = getShowContactUsService;
            _removeContactUsService = removeContactUsService;
            _getSettingServices = settingServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? searchkey, int Page = 1)
		{
            var pagesize = _getSettingServices.Execute().Result.Data.ShowPerPage;
            var result =await _allContactUsService.Execute(new RequestGetContactUsDto
            {

                Page = Page,
                SearchKey = searchkey,
                PageSize = pagesize,
                Category = null,
                Tag = null
            });
			return View(result);
		}
		[HttpGet]
        public async Task<IActionResult> ViewContact(string Id)
        {
			var result = await _getShowContactUsService.Execute(Id);
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string contactId)
        {
            var result = await _removeContactUsService.Execute(contactId);
            return Json(result);
        }

    }
}
