using Store.Application.Interfaces.Contexs;
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
        public GetShowContactUsService(IDatabaseContext context)
        {
            _context = context;
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
                    LanguegeId=contactUs.LanguageId,
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
        public string LanguegeId { get; set; }
        public string?   Content  { get; set; }
    }
}
