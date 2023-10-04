using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant.OrderState;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Orders.Queries.GetOrderDetailForAdmin
{
    public interface IGetOrderDetailForAdmin
    {
        Task<ResultDto<OrderDetailAdminDto>> Execute(string orderId);
    }
    public class GetOrderDetailForAdmin : IGetOrderDetailForAdmin
    {
        private readonly IDatabaseContext _context;
        public GetOrderDetailForAdmin(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<OrderDetailAdminDto>> Execute(string orderId)
        {
            var orderDetail = _context.Orders
                 .Include(p => p.User)
                 .Include(p => p.OrderDetails)
                 .ThenInclude(p => p.Product)
                 .Include(p => p.RequestPay)
                 .ThenInclude(p => p.City)
                 .Where(p => p.Id == orderId)
                 .FirstOrDefault();
            if(orderDetail==null)
            {
                return new ResultDto<OrderDetailAdminDto>()
                {
                    IsSuccess=false,
                };
            }

            orderDetail.Seen = true;
           await _context.SaveChangesAsync();

            return new ResultDto<OrderDetailAdminDto>()
            {
                Data = new OrderDetailAdminDto()
                {
                    SumPrice = orderDetail.RequestPay.Amount,
                    PricePost = orderDetail.RequestPay.City.Cost,
                    Address = orderDetail.Address,
                    //Province = orderDetail.RequestPay.City.Province.ProvinceName,
                    City = orderDetail.RequestPay.City.CityName,
                    Postalcode = orderDetail.PostalCode,
                    OrderState = orderDetail.OrderState,
                    TrackingPost = orderDetail.TrackingPost,
                    RequestPayId = orderDetail.RequestPayId,
                    UserId = orderDetail.RequestPay.UserId,
                    Email = orderDetail.RequestPay.User.Email,
                    FullName = orderDetail.User.FullName,
                    Phone = orderDetail.User.PhoneNumber,
                    OrderId = orderDetail.Id,
                    OrderProductLists = orderDetail.OrderDetails.ToList().Select(p => new OrderProductListDto()
                    {
                        Price = p.Price,
                        ProductId = p.ProductId,
                        ProductName = p.Product.Name,
                        Count = p.Count,
                        PettyPrice= p.Price*p.Count,
                    }).ToList(),
                },
                IsSuccess = true,
            };

        }
    }
    public class OrderDetailAdminDto
    {
        public string OrderId { get; set; }
        public double SumPrice { get; set; }
        public double PricePost { get; set; }
        public string? Address { get; set; }
        public string? Postalcode { get; set; }
        public string? TrackingPost { get; set; }
        public string Province { get; set; }
        public string? City { get; set; }
        public string RequestPayId { get; set; }
        public OrderState OrderState { get; set; }
        public string UserId { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }


        public List<OrderProductListDto> OrderProductLists { get; set; }

    }
    public class OrderProductListDto
    {
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Count { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public double PettyPrice { get; set; }//ریز هزینه

    }
}
