using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.ContactsUs.Commands.RemoveContactUs;
using Store.Application.Services.ContactsUs.Queries.GetAllContactUs;
using Store.Application.Services.ContactsUs.Queries.GetShowContactUs;
using Store.Application.Services.Langueges.Queries;

namespace EndPointStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactUsController : Controller
	{
		private readonly IGetAllContactUsService _allContactUsService;
        private readonly IGetShowContactUsService _getShowContactUsService;
        private readonly IRemoveContactUsService _removeContactUsService;
		public ContactUsController(IGetAllContactUsService getAllContactUsService
            ,IGetShowContactUsService getShowContactUsService
            ,IRemoveContactUsService removeContactUsService
			)
        {
			_allContactUsService = getAllContactUsService;
            _getShowContactUsService = getShowContactUsService;
            _removeContactUsService = removeContactUsService;
        }
        public async Task<IActionResult> Index(RequestGetContactUsDto request)
		{
			var result =await _allContactUsService.Execute(request);
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
