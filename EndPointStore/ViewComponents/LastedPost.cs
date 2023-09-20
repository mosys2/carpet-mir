using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Blogs.Queries.GetLastedPostsForSite;
using Store.Application.Services.SettingsSite.Queries.GetLogoForSite;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "LastedPost")]
    public class LastedPost:ViewComponent
    {
        private readonly IBlogFacadSite _blogFacadSite;
        private readonly IStringLocalizer _localizer;
        public LastedPost(IBlogFacadSite blogFacadSite, IStringLocalizerFactory localizedFactory)
        {
            _blogFacadSite = blogFacadSite;
            _localizer = localizedFactory.Create("LastedPost", "EndPointStore");
        }
        public IViewComponentResult Invoke()
        {
            var lastedPost = _blogFacadSite.GetLastedPostsSiteService.Execute();
            ViewBag.StringLocalizer = _localizer;
            return View(viewName: "LastedPost", lastedPost.Result);
        }
    }
}
