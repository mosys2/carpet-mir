using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SettingsSite.Queries.GetDescriptionFooterForSite;
using Store.Application.Services.UsersAddress.Queries.GetAddressUserForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "DescriptionFooter")]
    public class DescriptionFooter:ViewComponent
    {
        private readonly IGetDescriptionFooterSiteService _getDescriptionFooterSiteService;
        public DescriptionFooter(IGetDescriptionFooterSiteService getDescriptionFooterSiteService)
        {
            _getDescriptionFooterSiteService = getDescriptionFooterSiteService;
        }
        public IViewComponentResult Invoke(string provinceId)
        {
          
            var description = _getDescriptionFooterSiteService.Execute();
            return View(viewName: "DescriptionFooter", description.Result);
        }
    }
}
