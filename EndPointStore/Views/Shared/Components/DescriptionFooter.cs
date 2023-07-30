using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Abouts.Queries;
using Store.Application.Services.SettingsSite.Queries.GetDescriptionFooterForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "DescriptionFooter")]
    public class DescriptionFooter:ViewComponent
    {
        private readonly IGetDescriptionFooterSiteService _getDescription;
        public DescriptionFooter(IGetDescriptionFooterSiteService getDescriptionFooterSiteService)
        {
			_getDescription = getDescriptionFooterSiteService;

		}
        public IViewComponentResult Invoke()
        {
          
            var description = _getDescription.Execute();
            return View(viewName: "DescriptionFooter", description.Result);
        }
    }
}
