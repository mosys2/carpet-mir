using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using Store.Common;
using Store.Common.Constant.OrderState;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Orders.Queries.GetOrderForAdmin
{
    public interface IGetOrdersForAdminService
    {
        Task<ResultDto<OrdrsAdminDto>> Execute(OrderState? orderState, string SearchKey, int Page , int PageSize );
    }
    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetOrdersForAdminService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto<OrdrsAdminDto>> Execute(OrderState? orderState,string SearchKey, int Page, int PageSize)
        {
            //string languageId = _language.Execute().Result.Data.Id ?? "";
            //if (string.IsNullOrEmpty(languageId))
            //{
            //    return new ResultDto<OrdrsAdminDto>
            //    {
            //        IsSuccess = false,
            //    };
            //}
            int totalRow = 0;
            var orders = _context.Orders
                 .Include(p => p.OrderDetails)
                 .ThenInclude(p=>p.Product)
                 .OrderByDescending(p => p.Id).AsQueryable();
            if (orderState != null)
            {
                orders = orders.Where(p => p.OrderState == orderState).AsQueryable();
            }
            return new ResultDto<OrdrsAdminDto>()
            {
                Data =new OrdrsAdminDto
                {
                ordersDtos= orders.Select(p => new OrdersDto
                {
                    InsertTime =Assistants.ConvertToShamsi(p.InsertTime.Value.ToString()),
                    OrderState = p.OrderState,
                    OrderId = p.Id,
                    ProductCount = p.OrderDetails.Count(),
                    RequestId = p.RequestPayId,
                    UserId = p.UserId,
                    Seen = p.Seen
                }).ToPaged(Page,PageSize, out totalRow).ToList()
                ,
               TotalRow= totalRow,
               Paginate= Pagination.PaginateAdmin(Page,PageSize,totalRow,"Orders",SearchKey,"","")
                },
                IsSuccess = true,
            };
        }
    }

    public class OrdersDto
    {
        public string? NameProduct { get; set; }
        public string OrderId { get; set; }
        public string InsertTime { get; set; }
        public string RequestId { get; set; }
        public string UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }
        public string? FullName { get; set; }
        public bool Seen { get; set; }
    }
    public class OrdrsAdminDto
    {
        public int TotalRow { get; set; }
        public string? Paginate { get; set; }
        public List<OrdersDto> ordersDtos { get; set; }
    }
}
