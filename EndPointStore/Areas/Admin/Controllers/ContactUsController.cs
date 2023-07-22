using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.ContactsUs.Queries.GetAllContactUs;

namespace EndPointStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactUsController : Controller
	{
		private readonly IGetAllContactUsService _allContactUsService;
        public ContactUsController(IGetAllContactUsService getAllContactUsService)
        {
			_allContactUsService = getAllContactUsService;
        }
        public async Task<IActionResult> Index(RequestGetContactUsDto request)
		{
			var result =await _allContactUsService.Execute(request);
			return View(result);
		}
	}
}
