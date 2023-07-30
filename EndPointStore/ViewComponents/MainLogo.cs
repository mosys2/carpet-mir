using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SettingsSite.Queries.GetLogoForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
	[ViewComponent(Name = "MainLogo")]
	public class MainLogo:ViewComponent
	{
		private readonly IGetLogoSiteService _getLogoSiteService;
		public MainLogo(IGetLogoSiteService getLogoSiteService)
		{
			_getLogoSiteService = getLogoSiteService;
		}
		public IViewComponentResult Invoke()
		{
			var LogoFooter = _getLogoSiteService.Execute();
			return View(viewName: "MainLogo", LogoFooter.Result);
		}
	}
}
