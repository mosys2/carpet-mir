using EndPointStore.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Orders.Queries.GetUserOrderDetail;
using Store.Application.Services.Orders.Queries.GetUserOrders;

namespace EndPointStore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IGetUserOrdersService _getUserOrdersService;
        private readonly IGetUserOrderDetailService _getUserOrderDetailService;
        public OrdersController(IGetUserOrdersService getUserOrdersService,
           IGetUserOrderDetailService getUserOrderDetailService)
        {
            _getUserOrdersService = getUserOrdersService;
            _getUserOrderDetailService = getUserOrderDetailService;
        }
        public async Task<IActionResult> Index()
        {
            string? userId = ClaimUtility.GetUserId(User);
            var orders = await _getUserOrdersService.Execute(userId);
            return View(orders.Data);
        }
        public async Task<IActionResult> OrderDetail(string orderId)
        {
            var detailResult = await _getUserOrderDetailService.Execute(orderId);
            return View(detailResult.Data);
        }
    }
}
