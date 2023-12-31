﻿using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
using Store.Application.Services.Langueges.Queries;
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
        private readonly IGetSelectedLanguageServices _language;

        public EditAboutService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute(EditAboutDto editAbout)
		{
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
					Message=MessageInUser.NotFind
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

    }
}
