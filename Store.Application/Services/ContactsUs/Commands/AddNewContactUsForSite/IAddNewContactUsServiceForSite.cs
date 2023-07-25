using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public AddNewContactUsServiceForSite(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute(ContactUsDto contactUsDto)
		{
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
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
			return new ResultDto()
			{
				IsSuccess = true,
				Message = MessageInUser.MessageInsert
			};
		}
	}
	public class ContactUsDto
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Email { get; set; }
		public string? Mobile { get; set; }
		public string? Text { get; set; }
	}
}
