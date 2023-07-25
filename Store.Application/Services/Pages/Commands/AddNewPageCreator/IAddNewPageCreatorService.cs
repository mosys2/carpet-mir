using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.HomePages.Commands.AddNewSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Pages;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Pages.Commands.AddNewPageCreator
{
    public interface IAddNewPageCreatorService
    {
        Task<ResultDto> Execute(PageCreatorDto pageCreatorDto);
    }
    public class AddNewPageCreatorService : IAddNewPageCreatorService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public AddNewPageCreatorService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute(PageCreatorDto pageCreatorDto)
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
            var checkSlug=await _context.PageCreators.Where(q=>q.Slug== pageCreatorDto.Slug).FirstOrDefaultAsync();
            if(checkSlug != null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.ExistSlug
                };
            }
            PageCreator pageCreator = new PageCreator()
            {
                Id=Guid.NewGuid().ToString(),
                Content=pageCreatorDto.Content,
                Description=pageCreatorDto.Description,
                MetaTagKeyWords=pageCreatorDto.MetaTagKeyWords,
                LanguageId=languageId,
                Slug=pageCreatorDto.Slug,
                Title=pageCreatorDto.Title,
                MetaTagDescription=pageCreatorDto.MetaTagDescription,
                IsActive = pageCreatorDto.IsActive,
                InsertTime=DateTime.Now
            };
            await _context.PageCreators.AddAsync(pageCreator);
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class PageCreatorDto
    {
        [Required]
        public string Title { get; set; }
        //[Required]
        public string? Content { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public string? MetaTagKeyWords { get; set; }
        public string? MetaTagDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
