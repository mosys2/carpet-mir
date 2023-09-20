using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace EndPointStore.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IStringLocalizer _localizer;
        public Search(IStringLocalizerFactory localizedFactory)
        {
            _localizer = localizedFactory.Create("Search", "EndPointStore");
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.StringLocalizer = _localizer;
            return View(viewName: "Search");
        }
   }
}
