using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Settings;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SettingsSite.Commands
{
    public interface IEditSettingServices
    {
        Task<ResultDto> Execute(EditSettingDto request);
    }
    public class EditSettingServices : IEditSettingServices
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public EditSettingServices(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }

        public async Task<ResultDto> Execute(EditSettingDto request)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            var settingItem = await _context.Settings.Where(p=>p.LanguageId==languageId).FirstOrDefaultAsync();
            if (settingItem == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            settingItem.BaseUrl = request.BaseUrl;
            settingItem.ShowPerPage = request.ShowPerPage;
            settingItem.Logo2 = request.Logo2;
            settingItem.MetaTags = request.KeyWords;
            settingItem.Description= request.Description;
            settingItem.Logo= request.Logo;
            settingItem.Icon= request.Icon;
            settingItem.SiteName = request.SiteName;
            settingItem.UpdateTime=DateTime.Now;
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message=MessageInUser.RegisterSuccess
            };

        }
    }
    public class EditSettingDto
    {
        public string? SiteName { get; set; }
        public string? BaseUrl { get; set; }
        public string? Logo { get; set; }
        public string? Logo2 { get; set; }
        public string? Icon { get; set; }
        [Required]
        public int ShowPerPage { get; set; }
        public string? KeyWords { get; set; }
        public string? Description { get; set; }
    }
}
