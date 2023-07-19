using Store.Application.Interfaces.Contexs;
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
        public AddNewAuthorService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Excute(AuthorDto author)
        {
            var languege = await _context.Languages.FindAsync(author.LanguegeId);
            if (languege == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind,
                };
            }
            Author authors = new Author()
            {
                Id=Guid.NewGuid().ToString(),
                Name=author.Name,
                IsActive=author.IsActive,
                LanguageId=languege.Id,
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
        public string LanguegeId { get; set; }
        public bool IsActive { get; set; }
    }
}
