using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Newsletters;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Newsletters.Commands.AddNewsletter
{
    public interface IAddNewsletterservice
    {
        Task<ResultDto> Execute(string Email);
    }
    public class AddNewsletterservice : IAddNewsletterservice
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public AddNewsletterservice(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language=language;
        }

        public async Task<ResultDto> Execute(string Email)
        {
            try
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
                var checkRegister= _context.Newsletters.Where(p=>p.Email==Email && p.LanguageId==languageId).ToList();
                if(checkRegister.Any())
                {
                    return new ResultDto
                    {
                        IsSuccess=false,
                        Message=MessageInUser.MessageExistNewsletterEn
                    };
                }
                Newsletter newsletter = new Newsletter
                {
                    Id=Guid.NewGuid().ToString(),
                    Email=Email,
                    InsertTime=DateTime.Now,
                    LanguageId=languageId
                };
                await _context.Newsletters.AddAsync(newsletter);
                await _context.SaveChangesAsync();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message=MessageInUser.RegisterSuccessEn
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess=false,
                    Message=MessageInUser.RegisterFieldEn
                };
            }
        }
    }
    public class NewsletterDto
    {
        [Required]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string EmailNewsletter { get; set; }
    }
}
