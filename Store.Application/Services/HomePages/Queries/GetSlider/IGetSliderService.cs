using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Constant.NoImage;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePages.Queries.GetSlider
{
    public interface IGetSliderService
    {
        Task<List<ListSliderDto>> Execute();
    }
    public class GetSliderService : IGetSliderService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetSliderService(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _configuration = configuration;
            _language=languege;
        }
        public async Task<List<ListSliderDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<ListSliderDto>
                {
                  
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var slider =await _context.Sliders.Where(q => q.LanguageId == languageId).OrderByDescending(o=>o.InsertTime).Select(w => new ListSliderDto
            {
                Id = w.Id,
                Description = w.Description,
                Link = w.Link,
                IsActive=w.IsActive,
                Title = w.Title,
                UrlImage =BaseUrl+w.UrlImage,
                Url=w.UrlImage,
                InsertTime = w.InsertTime,
            }).ToListAsync();
            return slider;
        }
    }
    public class ListSliderDto
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? UrlImage { get; set; }
        public string? Url { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
