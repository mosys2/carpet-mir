using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Blogs.Queries.GetLastedPostsForSite;
using Store.Application.Services.SettingsSite.Queries.GetLogoForSite;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "LastedPost")]
    public class LastedPost:ViewComponent
    {
        private readonly IBlogFacadSite _blogFacadSite;
        public LastedPost(IBlogFacadSite blogFacadSite)
        {
            _blogFacadSite = blogFacadSite;
        }
        public IViewComponentResult Invoke()
        {
            var lastedPost = _blogFacadSite.GetLastedPostsSiteService.Execute();
            return View(viewName: "LastedPost", lastedPost.Result);
        }
    }
}
