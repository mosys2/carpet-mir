using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Menu.Queries.IGetMenuForSite;
using Store.Application.Services.SettingsSite.Queries.GetDescriptionFooterForSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class Menu:ViewComponent
    {
        private readonly IGetMenuSiteService _getMenuSiteService;
        public Menu(IGetMenuSiteService getMenuSiteService)
        {
            _getMenuSiteService = getMenuSiteService;

        }
        public IViewComponentResult Invoke()
        {
            var menu = _getMenuSiteService.Execute();

			// تبدیل داده‌های منو به کد HTML
			string menuHtml = "<ul class='nav navbar-nav margin-80px-bottom' id='menu-sc'>";
			foreach (var menuItem in menu.Result)
			{
				menuHtml += RenderMenuItem(menuItem);
			}
			menuHtml += "</ul>";

			ViewBag.MenuHtml = menuHtml;
			return View(viewName: "Menu");
        }
		private string RenderMenuItem(MenuItemSiteDto menuItem)
		{
			string result = "<li class='dropdown'>";
			result += $"<a href='{menuItem.Link}' title='{menuItem.Title}' data-bs-toggle='dropdown'>{menuItem.Title} ";

			if (menuItem.Sub != null && menuItem.Sub.Count > 0)
			{
				result += "<i class='fas fa-angle-right pull-right'></i></a>";
				result += "<ul class='dropdown-menu second-level'>";
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
