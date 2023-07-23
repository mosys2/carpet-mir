using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
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
		public AddNewContactUsServiceForSite(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<ResultDto> Execute(ContactUsDto contactUsDto)
		{
			var languege = await _context.Languages.FindAsync(contactUsDto.LanguageId);
			if (languege == null)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = MessageInUser.NotFind,
				};
			}
			ContactUs contactUs = new ContactUs()
			{
				Id = Guid.NewGuid().ToString(),
				LanguageId = languege.Id,
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
		public string LanguageId { get; set; }
	}
}
