using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ContactsUs.Commands.RemoveContactUs
{
	public interface IRemoveContactUsService
	{
		Task<ResultDto> Execute(string IdContactUs);
	}
	public class RemoveContactUsService : IRemoveContactUsService
	{
		private readonly IDatabaseContext _context;
		public RemoveContactUsService(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<ResultDto> Execute(string IdContactUs)
		{
			var contactUs = await _context.ContactUs.FindAsync(IdContactUs);
			if (contactUs == null)
			{
				return new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.NotFind
				};
			}
			contactUs.IsRemoved = true;
			contactUs.RemoveTime = DateTime.Now;
			await _context.SaveChangesAsync();
			return new ResultDto
			{
				IsSuccess = true,
				Message = MessageInUser.Delete
			};
		}
	}
}
