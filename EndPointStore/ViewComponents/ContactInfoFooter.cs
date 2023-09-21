using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;
using Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "ContactInfoFooter")]

    public class ContactInfoFooter:ViewComponent
    {
        private readonly IGetContactInfoSiteService _getContactInfoSiteService;
        private readonly IStringLocalizer _localizer;
        public ContactInfoFooter(IGetContactInfoSiteService getContactInfoSiteService, IStringLocalizerFactory localizedFactory)
        {
            _getContactInfoSiteService = getContactInfoSiteService;
            _localizer = localizedFactory.Create("ContactInfoFooter", "EndPointStore");
        }
        public IViewComponentResult Invoke()
        {
            var ContactInfoList = _getContactInfoSiteService.Execute();
            ViewBag.StringLocalizer = _localizer;
            return View(viewName: "ContactInfoFooter", ContactInfoList.Result);
        }
    }
}
