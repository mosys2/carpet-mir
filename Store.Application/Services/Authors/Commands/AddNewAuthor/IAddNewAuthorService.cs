using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Authors.Commands.AddNewAuthor
{
    public interface IAddNewAuthorService
    {
        Task<ResultDto> Excute(AuthorDto author);
    }
    public class AddNewAuthorService : IAddNewAuthorService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public AddNewAuthorService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Excute(AuthorDto author)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message=MessageInUser.NotFind
                };
            }
            if (author.Id != null)
            {
                var resultEdit = await _context.Authors.FindAsync(author.Id);
                resultEdit.Name = author.Name;
                resultEdit.Description= author.Description;
                resultEdit.IsActive=author.IsActive;
                resultEdit.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageInsert
                };
            }
            Author authors = new Author()
            {
                Id = Guid.NewGuid().ToString(),
                Name = author.Name,
                IsActive = author.IsActive,
                LanguageId =languageId,
                Description=author.Description,
                InsertTime=DateTime.Now,
            };
           await _context.Authors.AddAsync(authors);
           await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class AuthorDto
    {
        public string? Id { get; set; }
        public string   Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
