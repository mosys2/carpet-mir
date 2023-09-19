using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Store.Application.Interfaces.FacadPatternSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "TagBlog")]
    public class TagBlog:ViewComponent
    {
        private readonly IBlogFacadSite _blogFacadSite;
        private readonly IStringLocalizer _localizer;
        public TagBlog(IBlogFacadSite blogFacadSite, IStringLocalizerFactory localizedFactory)
        {
            _blogFacadSite = blogFacadSite;
            _localizer = localizedFactory.Create("BlogTag", "EndPointStore");
        }
        public IViewComponentResult Invoke()
        {
            var tags = _blogFacadSite.GetTagBlogSiteService.Execute();
            ViewBag.StringLocalizer = _localizer;
            return View(viewName: "TagBlog", tags.Result);
        }
    }
}
