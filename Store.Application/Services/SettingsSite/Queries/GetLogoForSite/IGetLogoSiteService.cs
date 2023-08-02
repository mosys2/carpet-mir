using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;
using Store.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SettingsSite.Queries.GetLogoForSite
{
    public interface IGetLogoSiteService
    {
        Task<GetLogoSiteDto> Execute();
    }
    public class GetLogoSiteService : IGetLogoSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetLogoSiteService(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices language)
        {
            _context = context;
            _configuration = configuration;
            _language = language;
        }
        public async Task<GetLogoSiteDto> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new GetLogoSiteDto
                {

                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var LogoSite = _context.Settings.Where(q => q.LanguageId == languageId && q.IsRemoved == false)
               .OrderByDescending(p => p.InsertTime).FirstOrDefault();
            if (LogoSite == null)
            {
                return new GetLogoSiteDto
                {

                };
            }
            return new GetLogoSiteDto
            {
                Logo=!string.IsNullOrEmpty(LogoSite.Logo)?BaseUrl + LogoSite.Logo:"",
			   Logo2 = !string.IsNullOrEmpty(LogoSite.Logo) ? BaseUrl + LogoSite.Logo2 :"",
            };
        }
    }
    public class GetLogoSiteDto
    {
        public string? Logo { get; set; }
        public string? Logo2 { get; set; }
    }
}
