using Microsoft.Build.Framework;
using Microsoft.Extensions.Localization;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SettingsSite.Queries;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Contacts;
using Store.Infrastracture.Email;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MailKit.Net.Imap.ImapEvent;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Store.Application.Services.ContactsUs.Commands.AddNewContactUsForSite
{
	public interface IAddNewContactUsServiceForSite
	{
		Task<ResultDto> Execute(ContactUsDto contactUsDto);
	}
	public class AddNewContactUsServiceForSite : IAddNewContactUsServiceForSite
	{
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        private readonly ISendEmailService _sendEmailService;
        private readonly IGetAdminUsersService _getAdminUsers;
		private readonly IGetSettingServices _getSetting;
        private readonly IStringLocalizer _localizer;

        public AddNewContactUsServiceForSite(IDatabaseContext context,
			IGetSelectedLanguageServices languege,
			IGetAdminUsersService getAdminUsers,
			ISendEmailService sendEmailService,
            IStringLocalizerFactory localizedFactory,
            IGetSettingServices getSetting)
        {
            _context = context;
            _language = languege;
			_sendEmailService = sendEmailService;
			_getAdminUsers = getAdminUsers;
			_getSetting=getSetting;
            _localizer = localizedFactory.Create("Message", "EndPointStore");
        }
        public async Task<ResultDto> Execute(ContactUsDto contactUsDto)
		{
            string languageId = _language.Execute().Result.Data.Id ?? "";
			string messageRegister = _localizer["Register"];
            string messageNotFound = _localizer["NotFound"];
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = messageNotFound
                };
            }
           
            ContactUs contactUs = new ContactUs()
			{
				Id = Guid.NewGuid().ToString(),
				LanguageId = languageId,
				Email = contactUsDto.Email,
				Text = contactUsDto.Text,
				Name = contactUsDto.Name,
				Mobile = contactUsDto.Mobile,
				InsertTime = DateTime.Now
			};
			await _context.ContactUs.AddAsync(contactUs);
			await _context.SaveChangesAsync();

			var adminList = _getAdminUsers.Execute(null).Result;
			var setting = _getSetting.Execute().Result;

            foreach (var item in adminList)
			{
				await _sendEmailService.Execute(new SendEmailDto
				{
					Body= $"متن پیام ارسالی: {contactUs.Text}",
					Subject=$"پیام دریافتی از وبسایت {setting.Data.SiteName}",
					Name=item.FullName,
					UserEmail=item.Email
				});
			}

			return new ResultDto()
			{
				IsSuccess = true,
				Message = messageRegister
            };
		}
	}
	public class ContactUsDto
	{
		[Required]
		public string Name { get; set; }
		[Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{1,4}(\d{7,15})?$", ErrorMessage = "Not a valid phone number")]
        public string? Mobile { get; set; }
		public string? Text { get; set; }
	}
}
