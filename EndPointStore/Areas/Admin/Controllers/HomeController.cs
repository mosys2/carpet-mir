using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            return View();
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
            catch(Exception ex)
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
