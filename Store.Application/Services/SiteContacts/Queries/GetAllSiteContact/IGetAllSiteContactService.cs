using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.HomePages.Queries.GetSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SiteContacts.Queries.GetAllSiteContact
{
    public interface IGetAllSiteContactService
    {
        Task<List<GetAllSiteContactDto>> Execute();
    }
    public class GetAllSiteContactService : IGetAllSiteContactService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllSiteContactService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<List<GetAllSiteContactDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetAllSiteContactDto>
                {
                   
                };
            }
            var siteContact = _context.SiteContacts.Where(q => q.LanguageId == languageId).Include(c=>c.SiteContactType).OrderByDescending(o => o.InsertTime).Select(w => new GetAllSiteContactDto
            {
                Id = w.Id,
                IsActive = w.IsActive,
                Title = w.Title,
                Value=w.Value,
                CssClass=w.CssClass,
                ContactType=w.SiteContactType.Title,
                ContactTypeId=w.SiteContactTypeId
            }).ToList();
            return siteContact;
        }
    }
    public class GetAllSiteContactDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public string? CssClass { get; set; }
        public string ContactType { get; set; }
        public string ContactTypeId { get; set; }

    }
}
