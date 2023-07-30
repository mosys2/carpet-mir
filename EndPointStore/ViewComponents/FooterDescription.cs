using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SettingsSite.Queries.GetDescriptionFooterForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
	[ViewComponent(Name = "FooterDescription")]
	public class FooterDescription:ViewComponent
	{
		private readonly IGetDescriptionFooterSiteService _getDescription;
		public FooterDescription(IGetDescriptionFooterSiteService getDescriptionFooterSiteService)
		{
			_getDescription = getDescriptionFooterSiteService;

		}
		public IViewComponentResult Invoke()
		{

			var description = _getDescription.Execute();
			return View(viewName: "FooterDescription", description.Result);
		}
	}
}
