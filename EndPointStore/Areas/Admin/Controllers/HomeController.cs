using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Dashboard;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class HomeController : Controller
    {
        private readonly IGetDashboardDataService _getDashboard;
        public HomeController(IGetDashboardDataService getDashboard)
        {
            _getDashboard=getDashboard;
        }

        public async Task<IActionResult> Index()
        {
            var dashboard = await _getDashboard.Execute();
            return View(dashboard);
        }

        [HttpPost]
        public async Task<IActionResult> GetDashboard()
        {
            var dashboard = await _getDashboard.Execute();
            return Json(dashboard);
        }
        #region Localization
        [HttpPost]
        public async Task<IActionResult> ChangeLanguage(string culture)
        {
            try
            {
                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
                return Json(new ResultDto
                {
                    IsSuccess= true,
                    Message=""
                });
            }
            catch (Exception ex)
            {
                return Json(new ResultDto
                {
                    IsSuccess= false,
                    Message=""
                });
            }

        }
        #endregion



    }

}
