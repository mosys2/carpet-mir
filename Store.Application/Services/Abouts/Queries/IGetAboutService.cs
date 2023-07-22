using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Abouts.Queries
{
	public interface IGetAboutService
	{
		Task<AboutUsDto> Execute(string? LangugeId);
	}
	public class GetAboutService : IGetAboutService
	{
		private readonly IDatabaseContext _context;
		

		public GetAboutService(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<AboutUsDto> Execute(string? LangugeId)
		{
			var About=_context.Abouts.AsQueryable();
			if(!string.IsNullOrEmpty(LangugeId))
			{
				About = About.Where(q => q.LanguageId == LangugeId);
			}
			return new AboutUsDto
			{
				Id=About.First().Id,
				Content = About.First().Content,
				Description = About.First().Description,
				Image = About.First().Image,
				MetaTag = About.First().MetaTag,
				Title = About.First().Title,
				Video = About.First().Video,
				LanguegeId=About.First().LanguageId
			};
		}
	}
	public class AboutUsDto
	{
        public string Id { get; set; }
        public string? Title { get; set; }
		public string? Description { get; set; }
        public string? MetaTag { get; set; }
        public string?	 Image { get; set; }
        public string? Video { get; set; }
        public string? Content { get; set; }
        public string LanguegeId { get; set; }

    }
}
