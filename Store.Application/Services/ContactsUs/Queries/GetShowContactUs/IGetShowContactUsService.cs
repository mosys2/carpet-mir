using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ContactsUs.Queries.GetShowContactUs
{
    public interface IGetShowContactUsService
    {
        Task<ResultDto<GetShowContactUsDto>> Execute(string IdContactUs);
    }
    public class GetShowContactUsService : IGetShowContactUsService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetShowContactUsService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto<GetShowContactUsDto>> Execute(string IdContactUs)
        {
            var contactUs =await _context.ContactUs.FindAsync(IdContactUs);
            if(contactUs==null)
            {
                return new ResultDto<GetShowContactUsDto>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind,
                };
            }
            contactUs.Seen = true;
            await _context.SaveChangesAsync();
            return new ResultDto<GetShowContactUsDto>
            {
                Data = new GetShowContactUsDto
                {
                    Content = contactUs.Text,
                    Email = contactUs.Email,
                    Mobile = contactUs.Mobile,
                    Name=contactUs.Name
                },
                IsSuccess = true,
            };
        }
    }
    public class GetShowContactUsDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public string?   Content  { get; set; }
    }
}
