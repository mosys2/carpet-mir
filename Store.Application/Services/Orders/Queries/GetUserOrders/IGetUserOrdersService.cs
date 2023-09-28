using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant.OrderState;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Orders.Queries.GetUserOrders
{
    public interface IGetUserOrdersService
    {
        Task<ResultDto<List<GetUserOrdersDto>>> Execute(string UserId);
    }
    public class GetUserOrdersService : IGetUserOrdersService
    {
        private readonly IDatabaseContext _context;
        public GetUserOrdersService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<GetUserOrdersDto>>> Execute(string UserId)
        {
            var orders =await _context.Orders
                .Include(p => p.RequestPay)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id).Select(p => new GetUserOrdersDto
                {
                    OrderId = p.Id,
                    OrderState = p.OrderState,
                    RequestPayId = p.RequestPayId,
                    Address = p.Address,
                    IsPay = p.RequestPay.IsPay,
                    SumAmount = p.RequestPay.Amount,
                    InsertDate = p.InsertTime,
                    TrackingPost = p.TrackingPost,
                }).ToListAsync();
            return new ResultDto<List<GetUserOrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };
        }
    }
    public class GetUserOrdersDto
    {
        public string OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public string RequestPayId { get; set; }
        public string? Address { get; set; }
        public double SumAmount { get; set; }
        public DateTime? InsertDate { get; set; }
        public bool IsPay { get; set; }
        public string? TrackingPost { get; set; }
    }
    public class orderDetailsDto
    {
        public string OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
