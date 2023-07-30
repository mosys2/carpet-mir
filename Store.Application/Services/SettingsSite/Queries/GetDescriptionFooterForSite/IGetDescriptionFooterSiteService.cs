using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SettingsSite.Queries.GetDescriptionFooterForSite
{
    public interface IGetDescriptionFooterSiteService
    {
        Task<DescriptionDto> Execute();
    }
    public class GetDescriptionFooterSiteService : IGetDescriptionFooterSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetDescriptionFooterSiteService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<DescriptionDto> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new DescriptionDto
                {
                    Description=""
                };
            }
             var description=await _context.Settings.Where(p=>p.LanguageId==languageId).FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(description.Description))
            {
                return new DescriptionDto
                {
                    Description = ""
                };
            }
            return new DescriptionDto
            {
                Description = description.Description
            };
        }
    }
    public class DescriptionDto
    {
        public string? Description { get; set; }
    }
}
