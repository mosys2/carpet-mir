using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Menu.Queries.IGetMenuForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
	[ViewComponent(Name = "MenuHeader")]

	public class MenuHeader:ViewComponent
	{
		private readonly IGetMenuSiteService _getMenuSiteService;
		public MenuHeader(IGetMenuSiteService getMenuSiteService)
		{
			_getMenuSiteService = getMenuSiteService;

		}
		public IViewComponentResult Invoke()
		{
			var menu = _getMenuSiteService.Execute();

			// تبدیل داده‌های منو به کد HTML
			string menuHtml = "<ul id='accordion' class='nav navbar-nav no-margin alt-font text-normal' data-in='animate__fadeIn' data-out='animate__fadeOut'>";
			foreach (var menuItem in menu.Result)
			{
				menuHtml += RenderMenuItem(menuItem);
			}
			menuHtml += "</ul>";

			ViewBag.MenuHeader = menuHtml;
			return View(viewName: "MenuHeader");
		}
		private string RenderMenuItem(MenuItemSiteDto menuItem)
		{
			string result = "<li class='dropdown simple-dropdown'>";
			result += $"<a href='{menuItem.Link}' title='{menuItem.Title}' data-bs-toggle='dropdown'>{menuItem.Title} ";

			if (menuItem.Sub != null && menuItem.Sub.Count > 0)
			{
				result += "<i class='fas fa-angle-down dropdown-toggle' data-bs-toggle='dropdown' aria-hidden='true'></i></a>";
				result += "<ul class='dropdown-menu' role='menu'>";
				foreach (var subMenuItem in menuItem.Sub)
				{
					result += RenderMenuItem(subMenuItem);
				}
				result += "</ul>";
			}
			result += "</li>";
			return result;
		}
	}
}
