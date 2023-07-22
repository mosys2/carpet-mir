using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.ContactsUs.Commands.AddNewContactUsForSite;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Controllers
{
	public class ContactUsController : Controller
	{
		private readonly IAddNewContactUsServiceForSite _addNewContactUsServiceForSite;
        public ContactUsController(IAddNewContactUsServiceForSite addNewContactUsServiceForSite)
        {
            _addNewContactUsServiceForSite = addNewContactUsServiceForSite;
        }
        public async Task<IActionResult> Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(ContactUsDto contactUsDto)
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var result =await _addNewContactUsServiceForSite.Execute(contactUsDto);
			return Json(result);
		}
	}
}
