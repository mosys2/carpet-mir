using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Abouts.Commands
{
	public interface IEditAboutService
	{
		Task<ResultDto> Execute(EditAboutDto editAbout);
	}
	public class EditAboutService : IEditAboutService
	{
		private readonly IDatabaseContext _context;
		public EditAboutService(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<ResultDto> Execute(EditAboutDto editAbout)
		{
			var languege = await _context.Languages.FindAsync(editAbout.LanguegeId);
			if (languege == null)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = MessageInUser.NotFind,
				};
			}
			var about =await _context.Abouts.FindAsync(editAbout.Id);
			if(about==null)
			{
				return new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.MessageInvalidOperation
				};
			}
			about.Content = editAbout.Content;
			about.Title = editAbout.Title;
			about.Description = editAbout.Description;
			about.Image=editAbout.Image;
			about.Video=editAbout.Video;
			about.LanguageId = editAbout.LanguegeId;
			about.MetaTag= editAbout.MetaTag;
			about.UpdateTime = DateTime.Now;
			await _context.SaveChangesAsync();
			return new ResultDto
			{
				IsSuccess = true,
				Message = MessageInUser.MessageInsert
			};
		}
	}
	public class EditAboutDto
	{
		[Required]
		public string Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? MetaTag { get; set; }
		public string? Image { get; set; }
		public string? Video { get; set; }
		public string? Content { get; set; }
        public string LanguegeId { get; set; }

    }
}
