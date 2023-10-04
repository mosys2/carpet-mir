using Microsoft.Build.Framework;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Pages.Commands.AddNewPageCreator;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Pages.Commands.EditPageCreator
{
    public interface IEditPageCreatorService
    {
        Task<ResultDto> Execute(EditPageCreatorDto editPage);
    }
    public class EditPageCreatorService : IEditPageCreatorService
    {
        private readonly IDatabaseContext _context;
        public EditPageCreatorService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(EditPageCreatorDto editPageCreator)
        {
            
            var checkSlug =  _context.PageCreators.Where(q => q.Slug == editPageCreator.Slug).FirstOrDefault();
            if (checkSlug != null&&checkSlug.Id!= editPageCreator.Id)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.ExistSlug
                };
            }
            var editPages =await _context.PageCreators.FindAsync(editPageCreator.Id);
            if(editPages == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind,
                };
            }
            editPages.Slug= editPageCreator.Slug;
            editPages.Title = editPageCreator.Title;
            editPages.Description = editPageCreator.Description;
            editPages.Content= editPageCreator.Content;
            editPages.MetaTagDescription = editPageCreator.MetaTagDescription;
            editPages.MetaTagKeyWords = editPageCreator.MetaTagKeyWords;
            editPages.IsActive= editPageCreator.IsActive;
            editPages.UpdateTime= DateTime.Now;
            editPages.Image= editPageCreator.Image;
            editPages.GroupItemId = editPageCreator.GroupItemId;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class EditPageCreatorDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        //[Required]
        public string? Content { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public string? MetaTagKeyWords { get; set; }
        public string? MetaTagDescription { get; set; }
        public bool IsActive { get; set; }
        public string? Image { get; set; }
        public string? GroupItemId { get; set; }
    }
}
