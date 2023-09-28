using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Orders.Commands.SetTrackingCode
{
    public interface ISetTrackingCodeService
    {
        Task<ResultDto> Execute(string orderId, string code);
    }
    public class SetTrackingCodeService : ISetTrackingCodeService
    {
        private readonly IDatabaseContext _context;
        public SetTrackingCodeService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(string orderId, string code)
        {
            
            var order = _context.Orders
                .Where(p => p.Id == orderId)
                .FirstOrDefault();

            if (order == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFindRequestPay
                };
            }
            order.TrackingPost = code;
         await   _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.RegisterTrackingCode
            };
        }
    }
}
