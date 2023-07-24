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

namespace Store.Application.Services.SettingsSite.Queries
{
    public interface IGetSettingServices
    {
        Task<ResultDto<SettingDto>> Execute();
    }

    public class GetSettingServices : IGetSettingServices
    {

        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetSettingServices(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }

        public async Task<ResultDto<SettingDto>> Execute()
        {
            string languageId =_language.Execute().Result.Data.Id.ToString();
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<SettingDto>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            var settingItem = await _context.Settings
                .Where(p => p.LanguageId == languageId)
                .Select(p => new SettingDto
                {
                    BaseUrl = p.BaseUrl,
                    Description = p.Description,
                    LanguageId = languageId,
                    Icon = p.Icon,
                    Logo = p.Logo,
                    Logo2 = p.Logo2,
                    MetaTags = p.MetaTags,
                    ShowPerPage = p.ShowPerPage,
                    SiteName = p.SiteName
                }).FirstOrDefaultAsync();

            if (settingItem == null)
            {
                return new ResultDto<SettingDto>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }

            return new ResultDto<SettingDto>
            {
                Data = settingItem,
                IsSuccess = true
            };
        }
    }

    public class SettingDto
    {
        public string? SiteName { get; set; }
        public string? BaseUrl { get; set; }
        public string? Logo { get; set; }
        public string? Logo2 { get; set; }
        public string? Icon { get; set; }
        public int ShowPerPage { get; set; }
        public string? MetaTags { get; set; }
        public string? Description { get; set; }
        public string? LanguageId { get; set; }
    }
}
