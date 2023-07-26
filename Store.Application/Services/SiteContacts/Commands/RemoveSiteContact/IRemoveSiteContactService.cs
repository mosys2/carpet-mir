using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SiteContacts.Commands.RemoveSiteContact
{
    public interface IRemoveSiteContactService
    {
        Task<ResultDto> Execute(string IdSiteContact);
    }
    public class RemoveSiteContactService : IRemoveSiteContactService
    {
        private readonly IDatabaseContext _context;
        public RemoveSiteContactService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdSiteContact)
        {
            var siteContact = await _context.SiteContacts.FindAsync(IdSiteContact);
            if (siteContact == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            siteContact.IsRemoved = true;
            siteContact.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.RemoveSiteContact
            };
        }
    }
}
