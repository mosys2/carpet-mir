using Store.Application.Interfaces.Contexs;
using Store.Application.Services.HomePages.Commands.AddNewSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SiteContacts.Commands.AddNewSiteContact
{
    public interface IAddNewSiteContactService
    {
        Task<ResultDto> Execute(AddNewSiteContactDto siteContactDto);
    }
    public class AddNewSiteContactService : IAddNewSiteContactService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public AddNewSiteContactService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute(AddNewSiteContactDto siteContactDto)
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
            if (siteContactDto.Id != null)
            {
                var SitecontactEdit = await _context.SiteContacts.FindAsync(siteContactDto.Id);
                if(SitecontactEdit==null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = MessageInUser.NotFind
                    };
                }
                SitecontactEdit.Title = siteContactDto.Title;
                SitecontactEdit.Value = siteContactDto.Value;
                SitecontactEdit.CssClass = siteContactDto.CssClass;
                SitecontactEdit.IsActive = siteContactDto.IsActive;
                SitecontactEdit.SiteContactTypeId = siteContactDto.ContactType;
                SitecontactEdit.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageInsert
                };
            }
           SiteContact siteContact = new SiteContact()
            {
               Id=Guid.NewGuid().ToString(),
               LanguageId=languageId,
               SiteContactTypeId=siteContactDto.ContactType,
               CssClass= siteContactDto.CssClass,
               Title=siteContactDto.Title,
               Value=siteContactDto.Value,
               Icon="-",
               IsActive=siteContactDto.IsActive,
               InsertTime=DateTime.Now,
           };
           await  _context.SiteContacts.AddAsync(siteContact);
           await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class AddNewSiteContactDto
    {
        public string? Id { get; set; }
        public string ContactType { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string? CssClass { get; set; }
        public bool IsActive { get; set; }
    }
}
