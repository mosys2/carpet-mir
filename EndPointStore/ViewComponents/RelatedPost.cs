using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Blogs.Queries.GetRelatedPostsForSite;
using Store.Application.Services.SettingsSite.Queries.GetLogoForSite;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "RelatedPost")]
    public class RelatedPost:ViewComponent
    {
        private readonly IBlogFacadSite _blogFacadSite;
        public RelatedPost(IBlogFacadSite blogFacadSite)
        {
            _blogFacadSite = blogFacadSite;
        }
        public IViewComponentResult Invoke()
        {
            var relatedPost = _blogFacadSite.GetRelatedPostsSiteService.Execute();
            return View(viewName: "RelatedPost", relatedPost.Result);
        }
    }
}
