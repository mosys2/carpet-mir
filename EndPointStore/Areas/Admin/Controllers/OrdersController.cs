using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Orders.Commands.ChangeStateOrder;
using Store.Application.Services.Orders.Commands.SetTrackingCode;
using Store.Application.Services.Orders.Queries.GetOrderDetailForAdmin;
using Store.Application.Services.Orders.Queries.GetOrderForAdmin;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant.OrderState;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly IGetSettingServices _getSettingServices;
        private readonly IGetOrdersForAdminService _getOrdersForAdminService;
        private readonly IGetOrderDetailForAdmin _getOrderDetailForAdmin;
        private readonly ISetTrackingCodeService _setTrackingCodeService;
        private readonly IChangeStateOrderService _changeStateOrderService;
        public OrdersController
            (
            IGetSettingServices getSettingServices
            ,IGetOrdersForAdminService getOrdersForAdminService
            ,IGetOrderDetailForAdmin getOrderDetailForAdmin
            ,ISetTrackingCodeService setTrackingCodeService
            , IChangeStateOrderService changeStateOrderService
            )
        {
            _getSettingServices = getSettingServices;
            _getOrdersForAdminService = getOrdersForAdminService; 
            _getOrderDetailForAdmin=getOrderDetailForAdmin;
            _setTrackingCodeService = setTrackingCodeService;
            _changeStateOrderService= changeStateOrderService;
        }
        public async Task<IActionResult> Index(OrderState? orderState, string searchkey, int page = 1)
        {
            var pagesize = _getSettingServices.Execute().Result.Data.ShowPerPage;
            var orders = await _getOrdersForAdminService.Execute
                (
                orderState,searchkey,page,pagesize
                );
            return View(orders.Data);
        }
        public async Task<IActionResult> OrderDetail(string orderId)
        {
            var result = await _getOrderDetailForAdmin.Execute(orderId);
            if(!result.IsSuccess)
            {

            }
            return View(result.Data);
        }
        public async Task<IActionResult> SetTrackingCode(string orderId, string code)
        {
            var result = await _setTrackingCodeService.Execute(orderId, code);
            return Json(result);
        }
        public async Task<IActionResult> ChangeState(string orderId, int stateId)
        {
            var result = await _changeStateOrderService.Execute(orderId, stateId);
            return Json(result);
        }
    }
}
