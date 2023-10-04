using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Constant.OrderState;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Orders.Commands.ChangeStateOrder
{
    public interface IChangeStateOrderService
    {
        Task<ResultDto> Execute(string orderId, int stateId);
    }
    public class ChangeStateOrderService : IChangeStateOrderService
    {
        private readonly IDatabaseContext _context;
        public ChangeStateOrderService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(string orderId, int stateId)
        {
            var order =await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFindRequestPay
                };
            }
            OrderState orderState = (OrderState)Enum.Parse(typeof(OrderState), stateId.ToString());

            var orderselect = _context.Orders
                .Where(p => p.Id == orderId)
                .SingleOrDefault();
            if(orderselect != null)
            {
                orderselect.OrderState = orderState;
               await _context.SaveChangesAsync();
            }
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.RegisterSuccess
            };
        }
    }

}
