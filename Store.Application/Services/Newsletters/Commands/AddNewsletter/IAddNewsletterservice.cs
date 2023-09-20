using Microsoft.Build.Framework;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer _localizer;

        public AddNewsletterservice(IDatabaseContext context,
            IStringLocalizerFactory localizedFactory,
            IGetSelectedLanguageServices language)
        {
            _context = context;
            _language=language;
            _localizer = localizedFactory.Create("Message", "EndPointStore");
        }

        public async Task<ResultDto> Execute(string Email)
        {
            try
            {
                string languageId = _language.Execute().Result.Data.Id ?? "";
                if (string.IsNullOrEmpty(languageId))
                {
                    string messageNotFound = _localizer["NotFound"];
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = messageNotFound
                    };
                }
                var checkRegister= _context.Newsletters.Where(p=>p.Email==Email && p.LanguageId==languageId).ToList();
                if(checkRegister.Any())
                {
                    string MessageExistNewsletter = _localizer["MessageExistNewsletter"];
                    return new ResultDto
                    {
                        IsSuccess=false,
                        Message= MessageExistNewsletter
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
                string registerNewsLatter = _localizer["Register"];
                return new ResultDto
                {
                    IsSuccess = true,
                    Message= registerNewsLatter
                };
            }
            catch (Exception ex)
            {
                string RegisterField = _localizer["RegisterFailed"];
                return new ResultDto
                {
                    IsSuccess=false,
                    Message= RegisterField
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
