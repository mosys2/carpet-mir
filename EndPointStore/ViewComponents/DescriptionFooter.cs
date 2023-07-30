using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SettingsSite.Queries.GetDescriptionFooterForSite;
namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "DescriptionFooter")]
    public class DescriptionFooter:ViewComponent
    {
        private readonly IGetDescriptionFooterSiteService _siteService;
        public DescriptionFooter(IGetDescriptionFooterSiteService siteService)
        {
			_siteService = siteService;
        }
        public IViewComponentResult Invoke()
        {
            var description = _siteService.Execute();
            return View(viewName: "DescriptionFooter", description.Result);
        }
    }
}
