using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Store.Application.Interfaces.FacadPatternSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "PopularPost")]
    public class PopularPost:ViewComponent
    {
        private readonly IBlogFacadSite _blogFacadSite;
        private readonly IStringLocalizer _localizer;

        public PopularPost(IBlogFacadSite blogFacadSite,IStringLocalizerFactory localizedFactory)
        {
            _blogFacadSite = blogFacadSite;
            _localizer = localizedFactory.Create("PopularPost", "EndPointStore");
        }
        public IViewComponentResult Invoke()
        {
            var popularPost = _blogFacadSite.GetPopularPostsSiteService.Execute();
            ViewBag.StringLocalizer = _localizer;
            return View(viewName: "PopularPost", popularPost.Result);
        }
    }
}
