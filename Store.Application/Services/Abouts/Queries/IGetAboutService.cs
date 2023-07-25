using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Abouts.Queries
{
	public interface IGetAboutService
	{
		Task<AboutUsDto> Execute();
	}
	public class GetAboutService : IGetAboutService
	{
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAboutService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<AboutUsDto> Execute()
		{
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new AboutUsDto
                {
                   
                };
            }
            var About=_context.Abouts.Where(q => q.LanguageId == languageId).AsQueryable();
			
			return new AboutUsDto
			{
				Id=About.First().Id,
				Content = About.First().Content,
				Description = About.First().Description,
				Image = About.First().Image,
				MetaTag = About.First().MetaTag,
				Title = About.First().Title,
				Video = About.First().Video,
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

    }
}
