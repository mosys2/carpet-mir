using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Orders.Queries.GetUserOrderDetail
{
    public interface IGetUserOrderDetailService
    {
        Task<ResultDto<List<OrderDetailsDto>>> Execute(string orderId);
    }
    public class GetUserOrderDetailService : IGetUserOrderDetailService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        public GetUserOrderDetailService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ResultDto<List<OrderDetailsDto>>> Execute(string orderId)
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var orderDetail =await _context.OrderDetails
               .Include(p => p.Product)
                .Where(p => p.OrderId == orderId)
                .OrderByDescending(p => p.InsertTime).Select(p => new OrderDetailsDto
                {
                    Count = p.Count,
                    Price = p.Price,
                    ProductName =string.IsNullOrEmpty(p.Product.Name)?"بدون نام": p.Product.Name,
                    ProductImage =string.IsNullOrEmpty(p.Product.Pic)?"":BaseUrl+p.Product.Pic,
                    OrderDetailId = p.Id,
                    ProductId = p.ProductId,
                }).ToListAsync();
            return new ResultDto<List<OrderDetailsDto>>()
            {
                Data = orderDetail,
                IsSuccess = true,
            };
        }
    }
    public class OrderDetailsDto
    {
        public string OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string? ProductImage { get; set; }
    }
}
