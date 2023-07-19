using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Authors.Commands.RemoveAuthor
{
    public interface IRemoveAuthorService
    {
        Task<ResultDto> Execute(string IdAuthor);

    }
    public class RemoveAuthorService : IRemoveAuthorService
    {
        private readonly IDatabaseContext _context;
        public RemoveAuthorService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdAuthor)
        {
            var author = await _context.Authors.FindAsync(IdAuthor);
            if (author == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نتیجه ایی یافت نشد!"
                };
            }
            author.IsRemoved = true;
            author.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.Delete
            };
        }
    }
}
