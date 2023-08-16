using EndPointStore.Models.ContactUsViewModel;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using Store.Application.Services.ContactsUs.Commands.AddNewContactUsForSite;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Infrastracture.Email;
using Store.Infrastracture.Sms;

namespace EndPointStore.Controllers
{
	public class ContactUsController : Controller
	{
		private readonly IAddNewContactUsServiceForSite _addNewContactUsServiceForSite;
        private readonly IGetContactInfoSiteService _getContactInfoSiteService;
		private readonly ISendEmailService _sendEmailService;
		private readonly ISendSmsService _sendSmsService;
        public ContactUsController(IAddNewContactUsServiceForSite addNewContactUsServiceForSite
			, ISendEmailService sendEmailService
			, ISendSmsService sendSmsService
            ,IGetContactInfoSiteService getContactInfoSiteService)
        {
            _addNewContactUsServiceForSite = addNewContactUsServiceForSite;
			_getContactInfoSiteService = getContactInfoSiteService;
			_sendEmailService= sendEmailService;
			_sendSmsService= sendSmsService;
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
<<<<<<< HEAD
            if (!ModelState.IsValid)
=======

			if (!ModelState.IsValid)
>>>>>>> adb74bfb77995d1c8e893c91b37712130c4c1a5c
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.InvalidFormEn
				});
			}
            var result =await _addNewContactUsServiceForSite.Execute(contactUsDto);
			return Json(result);
		}
	}
}
