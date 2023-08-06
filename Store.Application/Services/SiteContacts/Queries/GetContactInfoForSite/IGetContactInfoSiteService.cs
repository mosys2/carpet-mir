using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite;
using Store.Common.Constant;
using Store.Domain.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite
{
    public interface IGetContactInfoSiteService
    {
        Task<GetContactInfoSiteDto> Execute();
    }
    public class GetContactInfoSiteService : IGetContactInfoSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetContactInfoSiteService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<GetContactInfoSiteDto> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new GetContactInfoSiteDto
                {

                };
            }
            var contactInfoSite = _context.SiteContacts.Where(q => q.LanguageId == languageId&& q.IsRemoved == false&&q.IsActive)
                .Include(w => w.SiteContactType)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            if(contactInfoSite==null)
            {
                return new GetContactInfoSiteDto
                {

                };
            }
            return new GetContactInfoSiteDto
            {
                Address = contactInfoSite.Where(w=>w.SiteContactType.Value == ContactsTypeValue.Address).FirstOrDefault()?.Value,
                Phone = contactInfoSite.Where(w => w.SiteContactType.Value == ContactsTypeValue.Phone).FirstOrDefault()?.Value,
                Email = contactInfoSite.Where(w => w.SiteContactType.Value == ContactsTypeValue.Email).FirstOrDefault()?.Value,
                Map = contactInfoSite.Where(w => w.SiteContactType.Value == ContactsTypeValue.Map).FirstOrDefault()?.Value,

            };
        }
    }
    public class GetContactInfoSiteDto
    {
        public string?  Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Map { get; set; }
    }
}
