using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.HomePages.Queries.GetSlider;
using Store.Application.Services.Langueges.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePages.Queries.GetSliderForSite
{
    public interface IGetSliderForSiteService
    {
        Task<List<GetSliderForSiteDto>> Execute();
    }
    public class GetSliderForSiteService: IGetSliderForSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetSliderForSiteService(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _configuration = configuration;
            _language = languege;
        }

        public async Task<List<GetSliderForSiteDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetSliderForSiteDto>
                {

                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var slider = await _context.Sliders.Where(q => q.LanguageId == languageId&&q.IsActive).OrderByDescending(o => o.InsertTime).Select(w => new GetSliderForSiteDto
            {
               Id=w.Id,
               Image=BaseUrl+w.UrlImage,
               Name=w.Title,
               Link=w.Link
            }).ToListAsync();
            return slider;
        }
    }
    public class GetSliderForSiteDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string? Link { get; set; }
    }
}
