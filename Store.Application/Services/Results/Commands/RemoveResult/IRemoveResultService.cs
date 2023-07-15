using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Results.Commands.RemoveResult
{
    public interface IRemoveResultService
    {
        Task<ResultDto> Execute(string IdResult);
    }
    public class RemoveResultService : IRemoveResultService
    {
        private readonly IDatabaseContext _context;
        public RemoveResultService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdResult)
        {

            var result = await _context.Results.FindAsync(IdResult);
            if (result == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نتیجه ایی یافت نشد!"
                };
            }
            result.IsRemoved = true;
            result.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = false,
                Message = MessageInUser.RemoveSlider
            };
        }
    }
}
