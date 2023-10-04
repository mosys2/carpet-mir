using Dto.Payment;
using EndPointStore.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tls;
using Store.Application.Services.Carts;
using Store.Application.Services.Fainances.Commands.AddRequestPay;
using Store.Application.Services.Fainances.Commands.EditRequestPay;
using Store.Application.Services.Fainances.Queries.GetRequestPay;
using Store.Application.Services.Orders.Commands.AddNewOrder;
using Store.Application.Services.Posts.Queries;
using Store.Application.Services.UsersAddress.Queries.GetAddressUserForSite;
using ZarinPal.Class;

namespace EndPointStore.Controllers
{
    [Authorize("Customer")]
    public class PayController : Controller
    {
        private readonly IAddRequestPayService _addRequestPayService;
        private readonly ICartService _cartService;
        private readonly CookiesManager cookiesManager;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IGetCityForPayServices _getCityForPayServices;
        private readonly IGetRequestPayService _getRequestPayService;
        private readonly IEditRequestPayService _editRequestPayService;
        private readonly IAddNewOrderService _addNewOrderService;
        public PayController(IAddRequestPayService addRequestPayService,
            ICartService cartService
            ,IGetCityForPayServices getCityForPayServices
            , IGetRequestPayService getRequestPayService
            , IEditRequestPayService editRequestPayService
            , IAddNewOrderService addNewOrderService
            )
        {
            _addRequestPayService = addRequestPayService;
            _cartService = cartService;
            cookiesManager = new CookiesManager();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            _getCityForPayServices = getCityForPayServices;
            _getRequestPayService = getRequestPayService;
            _editRequestPayService= editRequestPayService;
            _addNewOrderService = addNewOrderService;
        }
        public async Task<IActionResult> Index(string cityId, string postCart, string address)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Authentication");
            }
            //Validation User Data
            var city = _getCityForPayServices.Execute(cityId).Result.Data;
            if (city.Count <= 0 || string.IsNullOrEmpty(postCart) || string.IsNullOrEmpty(address))
            {
                return RedirectToAction("Index", "cart");
            }
            //Get Cart Curent User
            string? userId = ClaimUtility.GetUserId(User);
            var cart =await _cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), userId);

            if (cart.Data.SumAmount > 0)
            {
                var requestPay =await _addRequestPayService.Execute(cart.Data.SumAmount, userId, city.SingleOrDefault().Id);
                UserAddressPayDto.CityId = cityId;
                UserAddressPayDto.PostCart = postCart;
                UserAddressPayDto.Address = address;
                //ارسال به درگاه پرداخت

                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = requestPay.Data.Phone,
                    CallbackUrl = $"http://localhost:59333/Pay/Verify?id={requestPay.Data.Id}",
                    Description = "پرداخت فاکتور شماره" + requestPay.Data.RequestPayId,
                    Email = requestPay.Data.Email,
                    Amount =(int)requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
            }
            else
            {
                return RedirectToAction("Index", "cart");
            }
        }
        public async Task<IActionResult> Verify(string id, string authority, string status)
        {
            var requestpay =_getRequestPayService.Execute(id).Result.Data;
            var verification = await _payment.Verification(new DtoVerification
            {
                Amount =(int)requestpay.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);
            string? userid = ClaimUtility.GetUserId(User);
            var cart =await _cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), userid, true);
            if (verification.Status == 100)
            {

             var resultOrder=await _addNewOrderService.Execute(new requestAddNewOrderService
                {
                    Address = UserAddressPayDto.Address,
                    CartId = cart.Data.CartId,
                    UserId = userid,
                    RequestPayId = requestpay.Id,
                    PostCart = UserAddressPayDto.PostCart,

                });
                if(resultOrder.IsSuccess)
                {
                    var resultEdit = await _editRequestPayService.Execute(requestpay.Id, verification.RefId, authority);
                    if (resultEdit.IsSuccess)
                    {
                        return RedirectToAction("Index", "Orders");
                    }
                }
            }
            else
            {

            }
            return View();
        }
    }
    public static class UserAddressPayDto
    {
        public static string CityId { get; set; }
        public static string PostCart { get; set; }
        public static string Address { get; set; }
    }
}

