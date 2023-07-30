using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SettingsSite.Queries.GetLogoForSite;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "LogoFooter")]

    public class LogoFooter:ViewComponent
    {

        private readonly IGetLogoSiteService _getLogoSiteService;
        public LogoFooter(IGetLogoSiteService getLogoSiteService)
        {
            _getLogoSiteService = getLogoSiteService;
        }
        public IViewComponentResult Invoke()
        {
            var LogoFooter = _getLogoSiteService.Execute();
            return View(viewName: "LogoFooter", LogoFooter.Result);
        }
    }
}
