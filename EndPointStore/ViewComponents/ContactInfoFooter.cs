using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;
using Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "ContactInfoFooter")]

    public class ContactInfoFooter:ViewComponent
    {
        private readonly IGetContactInfoSiteService _getContactInfoSiteService;
        public ContactInfoFooter(IGetContactInfoSiteService getContactInfoSiteService)
        {
            _getContactInfoSiteService = getContactInfoSiteService;
        }
        public IViewComponentResult Invoke()
        {
            var ContactInfoList = _getContactInfoSiteService.Execute();
            return View(viewName: "ContactInfoFooter", ContactInfoList.Result);
        }
    }
}
