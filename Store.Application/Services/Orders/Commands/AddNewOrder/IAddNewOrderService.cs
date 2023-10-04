using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Constant.OrderState;
using Store.Common.Dto;
using Store.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Orders.Commands.AddNewOrder
{
    public interface IAddNewOrderService
    {
        Task<ResultDto> Execute(requestAddNewOrderService request);
    }
    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDatabaseContext _context;
        public AddNewOrderService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(requestAddNewOrderService request)
        {
            var user =await _context.Users.FindAsync(request.UserId);
            var requestPay =await _context.RequestPays.FindAsync(request.RequestPayId);
            var cart = _context.Carts.Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .Where(p => p.Id == request.CartId).FirstOrDefault();

            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            cart.Finished = true;

            Order order = new Order()
            {
                Address = request.Address,
                InsertTime = DateTime.Now,
                OrderState = OrderState.Processing,
                RequestPay = requestPay,
                User = user,
                PostalCode = request.PostCart,
            };
          await  _context.Orders.AddAsync(order);

            List<OrderDetail> OrderDetaillist = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product,
                    InsertTime = DateTime.Now,
                };
                OrderDetaillist.Add(orderDetail);
            }
           await _context.OrderDetails.AddRangeAsync(OrderDetaillist);
           await _context.SaveChangesAsync();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.RegisterOrder
            };

        }
    }
    public class requestAddNewOrderService
    {
        public string CartId { get; set; }
        public string RequestPayId { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string PostCart { get; set; }
    }
}
