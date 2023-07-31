using EndPointStore.Models.ContactUsViewModel;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.ContactsUs.Commands.AddNewContactUsForSite;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Controllers
{
	public class ContactUsController : Controller
	{
		private readonly IAddNewContactUsServiceForSite _addNewContactUsServiceForSite;
        private readonly IGetContactInfoSiteService _getContactInfoSiteService;
        public ContactUsController(IAddNewContactUsServiceForSite addNewContactUsServiceForSite, IGetContactInfoSiteService getContactInfoSiteService)
        {
            _addNewContactUsServiceForSite = addNewContactUsServiceForSite;
			_getContactInfoSiteService = getContactInfoSiteService;

        }
        public async Task<IActionResult> Index()
		{
			var ContactInfo =await _getContactInfoSiteService.Execute();
            ContactUsViewModel contactUsViewModel = new ContactUsViewModel()
			{
				ContactUsModel = new ContactUsDto(),
				GetContactInfoSite= ContactInfo

            };
            return View(contactUsViewModel);
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
