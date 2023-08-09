using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Sizes.Commands.RemoveSize
{
    public interface IRemoveSizeService
    {
        Task<ResultDto> Execute(string IdSize);
    }
    public class RemoveSizeService : IRemoveSizeService
    {
        private readonly IDatabaseContext _context;
        public RemoveSizeService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdSize)
        {
            var size = await _context.Sizes.FindAsync(IdSize);
            if (size == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نتیجه ایی یافت نشد!"
                };
            }
            size.IsRemoved = true;
            size.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.Delete
            };
        }
    }
}
