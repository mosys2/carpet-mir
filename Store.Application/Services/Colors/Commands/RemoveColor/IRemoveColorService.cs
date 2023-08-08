using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Colors.Commands.RemoveColor
{
    public interface IRemoveColorService
    {
        Task<ResultDto> Execute(string IdColor);
    }
    public class RemoveColorService : IRemoveColorService
    {
        private readonly IDatabaseContext _context;
        public RemoveColorService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdColor)
        {
            var color = await _context.Colors.FindAsync(IdColor);
            if (color == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نتیجه ایی یافت نشد!"
                };
            }
            color.IsRemoved = true;
            color.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.Delete
            };
        }
    }
}
