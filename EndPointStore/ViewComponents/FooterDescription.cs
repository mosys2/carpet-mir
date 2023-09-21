using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Store.Application.Services.SettingsSite.Queries.GetDescriptionFooterForSite;
namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "FooterDescription")]
    public class FooterDescription : ViewComponent
    {
        private readonly IGetDescriptionFooterSiteService _siteService;
        private readonly IStringLocalizer _localizer;

        public FooterDescription(IGetDescriptionFooterSiteService siteService ,IStringLocalizerFactory localizedFactory)
        {
			_siteService = siteService;
            _localizer = localizedFactory.Create("FooterDescription", "EndPointStore");
        }
        public IViewComponentResult Invoke()
        {
            var description = _siteService.Execute();
            ViewBag.StringLocalizer = _localizer;
            return View(viewName: "FooterDescription", description.Result);
        }
    }
}
