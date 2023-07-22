using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
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
        Task<ResultDto> Execute(EditSettingDto request, string languageId);
    }
    public class EditSettingServices : IEditSettingServices
    {
        private readonly IDatabaseContext _context;
        public EditSettingServices(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(EditSettingDto request, string languageId)
        {
            var language = await _context.Languages.FindAsync(languageId);
            if (language == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            var settingItem = await _context.Settings.FirstOrDefaultAsync();
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
            settingItem.MetaTags = request.MetaTags;
            settingItem.Description= request.Description;
            settingItem.Logo= request.Logo;
            settingItem.Icon= request.Icon;
            settingItem.LanguageId = languageId;
            settingItem.SiteName = request.SiteName;
            settingItem.UpdateTime=DateTime.Now;
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message=MessageInUser.UploadSuccess
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
        public int ShowPerPage { get; set; }
        public string? MetaTags { get; set; }
        public string? Description { get; set; }
        public string LanguageId { get; set; }
    }
}
